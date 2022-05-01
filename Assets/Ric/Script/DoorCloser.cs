using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour
{  
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private GameObject _doorCollider;
    [SerializeField] private AudioSource _audioSource;
    private bool _soundHavePlayed = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !_doorAnimator.GetBool("_Closing") && !_soundHavePlayed)
        {
            _doorAnimator.SetBool("_Opening",false);
            _doorAnimator.SetBool("_Closing",true);
            _audioSource.Play();
            _soundHavePlayed = true;
            _doorCollider.GetComponent<BoxCollider>().enabled = true;
        }        
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player" && _doorAnimator.GetBool("_Closing"))
        {
            _doorAnimator.SetBool("_Closing",false);
        }       
    }
}
