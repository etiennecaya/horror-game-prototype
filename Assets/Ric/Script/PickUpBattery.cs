using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBattery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && FlashlightManager.Instance._currentBattery < FlashlightManager.Instance._MaxBattery)
        {
            FlashlightManager.Instance._currentBattery = FlashlightManager.Instance._MaxBattery;
        }
    }
}
