using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator _plateAnimator = null;
    [SerializeField] private AudioSource _movingDoorAudioSource = null;
    [SerializeField] private AudioSource _pressurePlateAudioSource = null;
    [SerializeField] private AudioClip _movingSound = null;
    [SerializeField] private AudioClip _reachedEnd = null;
    [SerializeField] private bool _playerIsOnPressurePlate = false;
    [SerializeField] private bool _doorReachedBottom = false;
    [SerializeField] private bool _doorReachedTop = false;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxHeight = 7.21f;
    [SerializeField] private float _minHeight = 2.302f;
    [SerializeField] Transform _doorTransform;

   private void Update() 
   {
       if (_playerIsOnPressurePlate)
       {
           MoveDoorUp();
       }
       else
       {
           MoveDoorDown();
       }
   }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            _playerIsOnPressurePlate = true;
            _pressurePlateAudioSource.Play();
            _movingDoorAudioSource.clip = _movingSound;
            _movingDoorAudioSource.Play();
            _plateAnimator.SetBool("PlateIsPressed",true);                  
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            _playerIsOnPressurePlate = false;
            _pressurePlateAudioSource.Play();
            _movingDoorAudioSource.clip = _movingSound;
            _movingDoorAudioSource.Play();
            _plateAnimator.SetBool("PlateIsPressed",false);   
        }
    }

    private void MoveDoorUp()
    {
        if(_doorReachedTop)
        {
            return;
        }
        if (_doorTransform.position.y >= _maxHeight)
        {   
            _moveSpeed = 0;
            _movingDoorAudioSource.Stop();
            _doorReachedTop = true; 
            _movingDoorAudioSource.loop = false;
            _movingDoorAudioSource.clip = _reachedEnd;
            _movingDoorAudioSource.Play();       
        }
        else
        {
            _moveSpeed = 3;
            _doorTransform.position += new Vector3(0,_moveSpeed * Time.deltaTime,0);
            _movingDoorAudioSource.loop = true;
            _doorReachedBottom = false;
        }
    }

    private void MoveDoorDown()
    {
        if(_doorReachedBottom)
        {
            return;
        }
        if (_doorTransform.position.y <= _minHeight)
        {
            _moveSpeed = 0;
            _movingDoorAudioSource.Stop();
            _doorReachedBottom = true; 
            _movingDoorAudioSource.loop = false;
            _movingDoorAudioSource.clip = _reachedEnd;
            _movingDoorAudioSource.Play();  
        }
        else
        {
            _moveSpeed = 0.2f;
            _doorTransform.position += new Vector3(0,-_moveSpeed * Time.deltaTime,0);
            _movingDoorAudioSource.loop = true;
            _doorReachedTop = false;
        }
    }

    private void Start() 
    {
        _doorReachedBottom = true;
    }
}
