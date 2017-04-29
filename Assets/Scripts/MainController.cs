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

    public Slider OxygenSlider;
    public Slider BurntSlider;
    public Text TimerText;

    float TimerTimeLeft;

    // Use this for initialization
    void Start()
    {
        Data.Controller = this;
        StartCoroutine(Init());
    }

    float GetCurrentPlayerHeight()
    {
        return Camera.main.transform.position.y;
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(5);
        InitHeight();
        FireSound.SetActive(true);
        Data.IsSmokeActivated = true;

        TimerTimeLeft = 90f;
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
}
