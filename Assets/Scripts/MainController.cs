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
            Data.ResetWinCondition();

            GetComponent<StickGenerator>().ClearObjects();

            IsReadyToStart = false;

            Smoke.SetActive(true);

            FireSound.SetActive(true);
            Data.IsSmokeActivated = true;

            TimerTimeLeft = 60f;

            GetComponent<StickGenerator>().enabled = true;

            Baby.GetComponent<Baby>().StartCry();

            ExitObject.GetComponent<MeshRenderer>().enabled = false;

            Data.IsEditorModeActive = false;
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

    private float ConvertRange(float originalStart, float originalEnd,
        float newStart, float newEnd, float value)
    {
        float scale = (newEnd - newStart) / (originalEnd - originalStart);
        return newStart + (value - originalStart) * scale;
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

            var healthOverlayAlpha = ConvertRange(0, 1, 0.75f, 1, Data.HealthAmount);
			HealthOverlayStatus.color = new Color(0.75f, 0, 0, 1 - healthOverlayAlpha);

            TimerTimeLeft -= Time.deltaTime;
            if (TimerTimeLeft < 0)
            {
                KillPlayer();
                TimerTimeLeft = 0;
                return;
            }

            var timeLeft = TimeSpan.FromSeconds(TimerTimeLeft);
            var secondsLeft = timeLeft.Seconds;
            var minutesLeft = timeLeft.Minutes;
            if (Data.IsSmokeActivated)
            {
                TimerText.text = string.Format("{0}:{1}",
                    minutesLeft >= 10 ? minutesLeft.ToString() : "0" + minutesLeft,
                    secondsLeft >= 10 ? secondsLeft.ToString() : "0" + secondsLeft);
            }

            if (Vector3.Distance(Camera.main.transform.position, ExitObject.transform.position) < 1.5f)
            {
                StartExitProcedure();
            }
        }
    }

    public void KillPlayer()
    {
        Data.IsSurvive = false;
        Finish();
    }

    public void CollidedWith(GameObject collidedWith)
    {
        if (collidedWith.tag == "Exit")
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
        Data.IsSurvive = true;
        Finish();
    }

    private void Finish()
    {
        Data.IsSmokeActivated = false;
        Data.ShowResults();
        Clicker.SetActive(true);
        IsReadyToStart = true;
    }

    public bool IsReadyToStart = false;

    public void Ready()
    {
        InitHeight();
        IsReadyToStart = true;
        Hud.SetActive(true);
        Clicker.SetActive(true);
    }

    public GameObject Hud;
    public GameObject Clicker;
}
