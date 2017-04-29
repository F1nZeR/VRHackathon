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
        OxygenAmount = 100;
        BurnsAmount = 0;
    }

    public static MainController Controller { get; set; }

    public static float FloorHeight { get; set; }
    public static bool IsSmokeActivated { get; set; }    

    public static float OxygenAmount { get; set; }
    public static float BurnsAmount { get; set; }

    public static float GetSmokeHeight()
    {
        return FloorHeight + 1.3f;
    }
    
    public static void DamagePlayer(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Fire:
                BurnsAmount += 0.1f;
                break;

            case DamageType.Smoke:
                OxygenAmount -= 0.1f;
                break;

            default:
                break;
        }

        if (BurnsAmount >= 100 || OxygenAmount <= 0)
        {
            Controller.KillPlayer();
        }
    }

    public static void HealPlayer(DamageType damageType)
    {
        if (BurnsAmount <= 0 || OxygenAmount >= 100)
        {
            return;
        }

        switch (damageType)
        {
            case DamageType.Fire:
                BurnsAmount -= 0.1f;
                break;

            case DamageType.Smoke:
                OxygenAmount += 0.1f;
                break;

            default:
                break;
        }

        if (BurnsAmount <= 0 || OxygenAmount >= 100)
        {
            BurnsAmount = 0;
            OxygenAmount = 100;
        }
    }
}
