using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealthLevel
{
    SlightlyDamaged,
    MediumDamaged,
    HighlyDamaged
}

public static class Data
{
    static Data()
    {
        PlayerHealth = 100f;
    }

    public static MainController Controller { get; set; }

    public static float PlayerHealth { get; set; }
    public static float FloorHeight { get; set; }
    public static float IsSmokeHurts { get; set; }    
    
    public static void DamageUser(float damageValue)
    {
        PlayerHealth -= damageValue;
        if (PlayerHealth < 0)
        {
            Controller.KillPlayer();
        }
        else
        {
            if (PlayerHealth > 80 && PlayerHealth < 100)
            {
                Controller.NotifyAboutHealth(HealthLevel.SlightlyDamaged);
            }
            else if (PlayerHealth > 40 && PlayerHealth <= 80)
            {
                Controller.NotifyAboutHealth(HealthLevel.MediumDamaged);
            }
            else
            {
                Controller.NotifyAboutHealth(HealthLevel.HighlyDamaged);
            }
        }
    }
}
