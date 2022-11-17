using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class Vibration : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager._camShake += VibrateMe;
    }
    private void OnDisable()
    {
        EventManager._camShake -= VibrateMe;
    }
    public void VibrateMe()
    {
        MMVibrationManager.Haptic(HapticTypes.MediumImpact);
    }
   
}
