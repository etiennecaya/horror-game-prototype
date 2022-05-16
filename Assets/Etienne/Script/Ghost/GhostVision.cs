using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostVision : MonoBehaviour
{
    [SerializeField] private Ghost _parent;
    [SerializeField] private float _visionAngle;
    private GameObject _target;
    private float _angleToTarget;

    private void Update()
    {
        if(_target == null)
        {
            return;
        }
        Vector3 directionToTarget = new Vector3(_target.transform.position.x,transform.position.y,_target.transform.position.z) - transform.position;
        _angleToTarget = Vector3.Angle(directionToTarget, transform.forward);

        if (Vector3.Angle(directionToTarget, transform.forward) <= _visionAngle)
        {
            _parent.Target = _target;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHurtBox"))
        {
            _target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHurtBox"))
        {
            _target = null;
            _parent.Target = null;
        }
    }
}
