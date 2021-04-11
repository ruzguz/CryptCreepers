using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType 
    {
        FireRateIncrease,
        PowerShot,
        Invulnerability
    }

    public PowerUpType powerUpType;
}
