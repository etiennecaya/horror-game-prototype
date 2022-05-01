using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !_doorAnimator.GetBool("_Opening"))
        {
            _doorAnimator.SetBool("_Opening",true);
            _audioSource.Play();
        }        
    }
}
