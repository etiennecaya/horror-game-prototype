using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectibleUiandObject : MonoBehaviour
{
    //public PlayerCharacter ThePlayer;
    [Header("Sounds")]
    [SerializeField]private AudioClip[] audioClipArray;
    private AudioSource _audioSource;

    [Header("Health")]
    [SerializeField] private GameObject _heartOne;
    [SerializeField] private GameObject _heartTwo;
    [SerializeField] private GameObject _heartThree;
    private int Health = 3;
    private bool _isHurt = false;

    [Header("Battery")]
    public float _batteryPile = 60f;



    void Start()
    {
       // _audioSource = gameObject.GetComponent<AudioSource>();
    }
    
 
    void Update()
    {
        EverythingHealth();
    }

    private void FixedUpdate()
    {
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
            ////bla bla bla checkpoint
        }
    }

    void EverythingBattery()
    {
        _batteryPile = _batteryPile - Time.deltaTime;
    }
    private void OnTriggerEnter (Collider other)
    {
        /*if (other.gameObject.tag == "Ghost" && !_isHurt)
        {
            _isHurt = true;
            StartCoroutine(Aouch());
            Health = Health - 1;
            Debug.Log("Toucher au bullet");
            _audioSource.clip = audioClipArray[0];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }*/
        if (other.gameObject.tag == "Health")
        {
            Health = Health + 1;
            Debug.Log("Toucher au firstaid");
            Destroy(other.gameObject);
           /* _audioSource.clip = audioClipArray[2];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();*/
        }
        if (other.gameObject.tag == "PowerUp")
        {
            Destroy(other.gameObject);
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

    IEnumerator Respawning()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
