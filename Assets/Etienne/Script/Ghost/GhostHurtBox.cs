using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHurtBox : MonoBehaviour
{
    [SerializeField] private Ghost _parent;

    private void Update()
    {
        if (!GameManager.Instance.LightCone.activeSelf)
        {
            _parent.IsAttacked = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FlashLightCone"))
        {
            _parent.IsAttacked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FlashLightCone"))
        {
            _parent.IsAttacked = false;
        }
    }
}
