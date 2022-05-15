using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private bool _isCharacterPushing = false;
   
    void Update()
    {
        if(transform.position == _target.position)
        {
            return;
        }
        else if (_isCharacterPushing && transform.position != _target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,_target.position,_moveSpeed * Time.deltaTime);
        }        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _isCharacterPushing = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _isCharacterPushing = false;
        }
    }
}
