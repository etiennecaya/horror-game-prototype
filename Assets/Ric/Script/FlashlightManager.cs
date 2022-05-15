using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightManager : MonoBehaviour
{
   public static FlashlightManager Instance;
   public PlayerController PlayerController = null;
   private AudioSource _audiosource = null;
   public int Battery = 1;
   public int MaxBattery = 1;
   //public float CurrentTime = 1f;
   //public bool CountDown = false;
   [Header ("Health Variables")]
   public int PlayerCurrentHealth = 1;
   public int PlayerMaxHealth = 1;

   [Header("UI Elements")]
   [SerializeField] private Image[] _hearts;
   [SerializeField] private Sprite _fullHeart;
   [SerializeField] private Sprite _emptyHeart;
   
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
        _audiosource = GetComponent<AudioSource>();
    }

    private void Start() 
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        PlayerController.ActivateInputs();
        UpdateHealth();
    }

    public void PlayFlashlightSound()
    {
        _audiosource.Play();
    }

    public void BatteryDrainOverTime()
    {
        
    }

    private void Update() 
    {
        //CurrentTime = CountDown ? CurrentTime -= Time.deltaTime : CurrentTime += Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        PlayerCurrentHealth -= amount;
        UpdateHealth();
    }
    

    public void UpdateHealth()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < PlayerCurrentHealth)
            {
                _hearts[i].sprite = _fullHeart;
            }
            else 
            {
                _hearts[i].sprite = _emptyHeart;
            }
        }
        if (PlayerCurrentHealth <= 0)
        {
            PlayerCurrentHealth = 0;
            //LoadYouDiedMenu();
        }
    }
}
