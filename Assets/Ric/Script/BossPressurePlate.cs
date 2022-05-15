using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPressurePlate : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            BossManager.Instance.PlatePressed();
            _animator.SetBool("PlateIsPressed",true);
            _audioSource.Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
