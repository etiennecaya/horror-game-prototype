using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateGrille : MonoBehaviour
{
    [SerializeField] private Animator _plateAnimator = null;
    private AudioSource _audioSource = null;
    [SerializeField] private AudioSource _pressurePlateAudioSource = null;
    [SerializeField] private AudioClip _movingSound = null;
    [SerializeField] private AudioClip _reachedEnd = null;
    private bool _playerIsOnPressurePlate = false;
    private bool _doorReachedTop = false;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxHeight = 7.21f;
    [SerializeField] Transform _doorTransform;

   private void Update() 
   {
       if (_playerIsOnPressurePlate)
       {
           MoveDoorUp();
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
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
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
            _moveSpeed = 6;
            _doorTransform.position += new Vector3(0,_moveSpeed * Time.deltaTime,0);
            _audioSource.loop = true;
        }
    }

    

    private void Start() 
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
