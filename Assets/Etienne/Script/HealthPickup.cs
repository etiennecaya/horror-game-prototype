using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int HealthRestored = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHurtBox"))
        {
            Destroy(gameObject);
        }
    }
}
