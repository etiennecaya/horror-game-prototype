using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance;
    public bool _doorCanBeOpen = false;
    private AudioSource _doorAudioSource = null;
    [SerializeField] private AudioSource _serializedAudioSource = null;
    [SerializeField] private AudioClip[] _audioClips;

    private Animator _doorAnimator;

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start() 
    {
        _doorAudioSource = GetComponent<AudioSource>();
        _doorAnimator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && _doorCanBeOpen && !_doorAnimator.GetBool("_Opening"))
        {
            _doorAnimator.SetBool("_Opening",true);
            int i = Random.Range(0,_audioClips.Length);
            _doorAudioSource.clip = _audioClips[i];
            _doorAudioSource.Play();
            _doorCanBeOpen = false;
        }
    }

    public void PlayClearSound()
    {
        _serializedAudioSource.Play();
    }
}
