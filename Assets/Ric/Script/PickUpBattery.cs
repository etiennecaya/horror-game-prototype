using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBattery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && UIManager.Instance._currentBattery < UIManager.Instance._MaxBattery)
        {
            UIManager.Instance._currentBattery = UIManager.Instance._MaxBattery;
            Destroy(gameObject);
        }
    }
}
