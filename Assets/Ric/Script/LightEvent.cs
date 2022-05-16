using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] private GameObject _lights;
    private AudioSource _audioSource;

    private void Start() 
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _lights.SetActive(true);
            if(_audioSource.clip != null)
            {
                _audioSource.Play();
            }
        }
    }
}
