using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    private void Start() 
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !_doorAnimator.GetBool("_Opening"))
        {
            _doorAnimator.SetBool("_Opening",true);
            int i = Random.Range(0,_audioClips.Length);
            _audioSource.clip = _audioClips[i];
            _audioSource.Play();
        }        
    }
}
