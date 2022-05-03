using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostVision : MonoBehaviour
{
    [SerializeField] private Ghost _parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parent.Target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parent.Target = null;
        }
    }
}
