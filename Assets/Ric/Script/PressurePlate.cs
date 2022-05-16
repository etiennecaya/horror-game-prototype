using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator _plateAnimator = null;
    private AudioSource _audioSource = null;
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
            _audioSource.clip = _movingSound;
            _audioSource.Play();
            _plateAnimator.SetBool("PlateIsPressed",true);                  
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            _playerIsOnPressurePlate = false;
            _pressurePlateAudioSource.Play();
            _audioSource.clip = _movingSound;
            _audioSource.Play();
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
            _audioSource.Stop();
            _doorReachedTop = true; 
            _audioSource.loop = false;
            _audioSource.clip = _reachedEnd;
            _audioSource.Play();       
        }
        else
        {
            _moveSpeed = 3;
            _doorTransform.position += new Vector3(0,_moveSpeed * Time.deltaTime,0);
            _audioSource.loop = true;
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
            _audioSource.Stop();
            _doorReachedBottom = true; 
            _audioSource.loop = false;
            _audioSource.clip = _reachedEnd;
            _audioSource.Play();  
        }
        else
        {
            _moveSpeed = 0.15f;
            _doorTransform.position += new Vector3(0,-_moveSpeed * Time.deltaTime,0);
            _audioSource.loop = true;
            _doorReachedTop = false;
        }
    }

    private void Start() 
    {
        _audioSource = GetComponent<AudioSource>();
        _doorReachedBottom = true;
    }
}
