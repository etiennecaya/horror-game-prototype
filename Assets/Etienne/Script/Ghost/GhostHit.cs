using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHit : MonoBehaviour
{
    [SerializeField] private Ghost _parent;
    public int Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parent.DidLastAttackHit = true;
        }
    }
}
