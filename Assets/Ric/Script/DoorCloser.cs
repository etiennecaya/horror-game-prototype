using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour
{  
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private GameObject _doorCollider;
    [SerializeField] private GameObject _ceiling;
    [SerializeField] private GameObject _directionalLight;
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
            StartCoroutine(LightingFX());
        }        
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player" && _doorAnimator.GetBool("_Closing"))
        {
            _doorAnimator.SetBool("_Closing",false);
        }       
    }

    private IEnumerator LightingFX()
    {
        _ceiling.SetActive(true);
        _directionalLight.SetActive(true);
        yield return new WaitForSeconds(.5f);
        _ceiling.SetActive(false);
        _directionalLight.SetActive(false);
    }
}
