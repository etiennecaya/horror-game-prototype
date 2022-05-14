using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleUiandObject : MonoBehaviour
{
    //public PlayerCharacter ThePlayer;
    [Header("Sounds")]
   // [SerializeField]private AudioClip[] audioClipArray;
    private AudioSource _audioSource;

    [Header("Health")]
    [SerializeField] private GameObject _heartOne;
    [SerializeField] private GameObject _heartTwo;
    [SerializeField] private GameObject _heartThree;
    public int Health = 3;
    private bool _isHurt = false;

    [Header("Battery")]
    [SerializeField] private float _maximumBattery;
    public bool FlashlightIsOn;
    private float _batteryPile = 60f;
    [SerializeField] private GameObject[] _lesBatteries;
    [SerializeField] private GameObject _leGameObjectQuiDisparraitQuandYaPuDeBatteries;
    [SerializeField] private GameObject _laLumiereDansLeUI;


    [Header("Respawn")]
    private Vector3 _lastCheckpoint;

    // Needs to be a list 
    private GameObject[] _lesObjetsARespawnQuandOnMeurt;



    void Start()
    {
        // needs to be changed, because this will overwrite the player's batterylevel after respawn???
       _batteryPile = _maximumBattery;
       _audioSource = gameObject.GetComponent<AudioSource>();
    }
    
 
    void Update()
    {
        EverythingHealth();
        EverythingBattery();
    }

   
    void EverythingHealth()
    {
        //************Hearts in the UI
        if (Health >= 1)
        {
            _heartOne.SetActive(true);
            if (Health >= 2)
            {
                _heartTwo.SetActive(true);
                if (Health >= 3)
                {
                    _heartThree.SetActive(true);
                    if (Health > 3)
                    {
                        Health = 3;
                    }
                }
                else
                {
                    _heartThree.SetActive(false);
                }
            }
            else
            {
                _heartTwo.SetActive(false);
            }
        }
        else
        {
            _heartOne.SetActive(false);
        }
        //************End Sequence
        if (Health < 1)
        {
            Respawn();
        }
    }

    void EverythingBattery()
    {
        if (_leGameObjectQuiDisparraitQuandYaPuDeBatteries)
        {
            if ((FlashlightIsOn)&& _batteryPile > 0)
        {
            _laLumiereDansLeUI.SetActive(true);
            _batteryPile = _batteryPile - Time.deltaTime;
            _leGameObjectQuiDisparraitQuandYaPuDeBatteries.SetActive(true);
        } else { 
            _laLumiereDansLeUI.SetActive(false);
            _leGameObjectQuiDisparraitQuandYaPuDeBatteries.SetActive(false);
        }
        
            if (_batteryPile <= 0)
            {
                FlashlightIsOn = false;
            }
            else
            {
                if (_batteryPile > 0)
                {
                    _lesBatteries[0].SetActive(true);
                }
                else
                {
                    _lesBatteries[0].SetActive(false);
                }
                if (_batteryPile >= (_maximumBattery * 0.2f))
                {
                    _lesBatteries[1].SetActive(true);
                }
                else
                {
                    _lesBatteries[1].SetActive(false);
                }
                if (_batteryPile >= (_maximumBattery * 0.4f))
                {
                    _lesBatteries[2].SetActive(true);
                }
                else
                {
                    _lesBatteries[2].SetActive(false);
                }
                if (_batteryPile >= (_maximumBattery * 0.6f))
                {
                    _lesBatteries[3].SetActive(true);
                }
                else
                {
                    _lesBatteries[3].SetActive(false);
                }
                if (_batteryPile >= (_maximumBattery * 0.8f))
                {
                    _lesBatteries[4].SetActive(true);
                }
                else
                {
                    _lesBatteries[4].SetActive(false);
                }
            }
        }
    }
    void Respawn()
    {
        _batteryPile = _maximumBattery;
        Health = 3;
        this.transform.position = _lastCheckpoint; //pas test� encore
        //ETIENNE HELP ME faire rapparaitre les trucs :D
    }
    private void OnTriggerEnter (Collider other)
    {
        /*if (other.gameObject.CompareTag("Ghost") && !_isHurt)
        {
            _isHurt = true;
            StartCoroutine(Aouch());
            Health = Health - 1;
            Debug.Log("Toucher au bullet");
            _audioSource.clip = audioClipArray[0];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }*/
        if (other.gameObject.CompareTag("Health"))
        {
            Health = Health + 1;
            other.gameObject.SetActive(false);
            /* _audioSource.clip = audioClipArray[2];
             _audioSource.PlayOneShot(_audioSource.clip);
             _audioSource.Play();*/
        }
        if (other.gameObject.CompareTag("Battery"))
        {
            _batteryPile = _maximumBattery;
            other.gameObject.SetActive(false);
           /* _audioSource.clip = audioClipArray[3];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();*/
        }
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            _lastCheckpoint = other.transform.position;
            
            /* _audioSource.clip = audioClipArray[3];
             _audioSource.PlayOneShot(_audioSource.clip);
             _audioSource.Play();*/
        }
    }
    IEnumerator Aouch()
    {
        yield return new WaitForSeconds(1f);
        _isHurt = false;
    }

    
}
