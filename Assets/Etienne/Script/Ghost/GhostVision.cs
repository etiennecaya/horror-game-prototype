using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostVision : MonoBehaviour
{
    [SerializeField] private Ghost _parent;
    [SerializeField] private float _visionAngle;
    private GameObject _target;

    private void Update()
    {
        if(_target == null)
        {
            return;
        }
        Vector3 directionToTarget = _target.transform.position - transform.position;

        if (Vector3.Angle(directionToTarget, transform.forward) <= _visionAngle)
        {
            _parent.Target = _target;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = null;
            _parent.Target = null;
        }
    }
}
