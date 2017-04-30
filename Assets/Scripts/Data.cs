using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Smoke,
    Fire
}

public static class Data
{
    static Data()
    {
        OxygenAmount = 1;
        HealthAmount = 1;
        ResetWinCondition();
    }

    public static MainController Controller { get; set; }

    public static float FloorHeight { get; set; }
    public static bool IsSmokeActivated { get; set; }    

    public static float OxygenAmount { get; set; }
    public static float HealthAmount { get; set; }

    public static bool IsEditorModeActive { get; set; }

    public static bool IsSurvive { get; set; }
    public static bool IsBabyTaken { get; set; }
    public static bool IsAlarmPressed { get; set; }

    public static void ResetWinCondition()
    {
        IsSurvive = false;
        IsBabyTaken = false;
        IsAlarmPressed = false;
    }

    public static float GetSmokeHeight()
    {
        return FloorHeight + 1.3f;
    }
    
    public static void DamagePlayer(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Fire:
                HealthAmount -= 0.004f;
                break;

            case DamageType.Smoke:
                OxygenAmount -= 0.002f;
                break;

            default:
                break;
        }

        if (HealthAmount <= 0)
        {
            Controller.KillPlayer();
        }

        if (OxygenAmount <= 0)
        {
            OxygenAmount = 0;
            HealthAmount -= 0.004f;
        }
        
        if (HealthAmount <= 0)
        {
            HealthAmount = 0;
            Controller.KillPlayer();
        }
    }

    public static void HealPlayer(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Fire:
                HealthAmount += 0.001f;
                break;

            case DamageType.Smoke:
                OxygenAmount += 0.001f;
                break;

            default:
                break;
        }

        if (HealthAmount >= 1)
        {
            HealthAmount = 1;
        }

        if (OxygenAmount >= 1)
        {
            OxygenAmount = 1;
        }
    }

    public static void ShowResults()
    {
        GameObject.Find("HUDCanvas").GetComponent<ShowResult>().Show();
    }
}
