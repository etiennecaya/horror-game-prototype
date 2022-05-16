using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioSource _musicPlayer;

    private void Start() 
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) 
    {
      if (other.CompareTag("Player"))
      {
          _musicPlayer.Stop();
          _audioSource.Play();
      }
    }
}
