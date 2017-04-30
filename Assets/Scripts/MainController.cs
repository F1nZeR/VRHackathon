using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public GameObject FireSound;
    public GameObject ExitObject;
    public GameObject Smoke;
    public GameObject Baby;

    public Slider OxygenSlider;
    public Slider BurntSlider;
    public Text TimerText;
	public Image HealthOverlayStatus;

    float TimerTimeLeft;

    // Use this for initialization
    void Start()
    {
        Data.Controller = this;
    }

    float GetCurrentPlayerHeight()
    {
        return Camera.main.transform.position.y;
    }

    public void StartVoice()
    {
        if (IsReadyToStart)
        {
            IsReadyToStart = false;

            Smoke.SetActive(true);

            FireSound.SetActive(true);
            Data.IsSmokeActivated = true;

            TimerTimeLeft = 90f;

            GetComponent<StickGenerator>().enabled = true;

            Baby.GetComponent<Baby>().StartCry();
        }
    }

    void InitHeight()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(Camera.main.transform.position,
                                new Vector3(0, -1, 0),
                                out hitInfo,
                                3f,
                                SpatialMappingControl.PhysicsRaycastMask);
        var height = Vector3.Distance(Camera.main.transform.position, hitInfo.point);
        if (Mathf.Abs(height) < 0.5f)
        {
            height = 1.8f;
        }
        Data.FloorHeight = -height;
    }

    void FixedUpdate()
    {
        if (Data.IsSmokeActivated)
        {
            if (GetCurrentPlayerHeight() >= Data.GetSmokeHeight())
            {
                Data.DamagePlayer(DamageType.Smoke);
            }
            else
            {
                Data.HealPlayer(DamageType.Smoke);
            }

            OxygenSlider.value = Data.OxygenAmount;
            BurntSlider.value = Data.HealthAmount;

			var healthOverlayColor = HealthOverlayStatus.color;
			healthOverlayColor.a = Mathf.Clamp(1 - Data.HealthAmount, 0, 0.7f);

            TimerTimeLeft -= Time.deltaTime;
            if (TimerTimeLeft < 0)
            {
                // todo: exit
                TimerTimeLeft = 0;
            }

            var timeLeft = TimeSpan.FromSeconds(TimerTimeLeft);
            var secondsLeft = timeLeft.Seconds;
            var minutesLeft = timeLeft.Minutes;
            TimerText.text = string.Format("{0}:{1}",
                minutesLeft >= 10 ? minutesLeft.ToString() : "0" + minutesLeft,
                secondsLeft >= 10 ? secondsLeft.ToString() : "0" + secondsLeft);
        }
    }

    public void KillPlayer()
    {
        // todo: kill user
    }

    public void CollidedWith(GameObject collidedWith)
    {
        if (collidedWith == ExitObject)
        {
            StartExitProcedure();
        }
        else if (collidedWith.tag == "Fire")
        {
            Data.DamagePlayer(DamageType.Fire);
        }
    }

    private void StartExitProcedure()
    {
        //TODO:EXIT!!
    }

    public bool IsReadyToStart = false;

    public void Ready()
    {
        InitHeight();
        IsReadyToStart = true;
        Hud.SetActive(true);
    }

    public GameObject Hud;
}
