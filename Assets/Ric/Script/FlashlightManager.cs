using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightManager : MonoBehaviour
{
   public static FlashlightManager Instance;
   public PlayerController PlayerController = null;
   private AudioSource _audiosource = null;

   [Header ("Battery Variables")]
   public Image BatteryBar = null;
   [SerializeField]private float _currentBattery = 1;
   [SerializeField]private float _MaxBattery = 100;
   [Range (0.1f,1)]
   public float BatteryDrainer = 1;
   public float LerpSpeed;
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
        _currentBattery = _MaxBattery;
        PlayerController.ActivateInputs();
        UpdateHealth();
    }

    public void PlayFlashlightSound()
    {
        _audiosource.Play();
    }


    private void Update() 
    {
        LerpSpeed = 3f * Time.deltaTime;
        BatteryDrainOverTime();
        BatteryBarFiller();        
        ColorChanger();
    }

    private void BatteryBarFiller()
    {
        BatteryBar.fillAmount = Mathf.Lerp(BatteryBar.fillAmount,_currentBattery/_MaxBattery,LerpSpeed);
    }

    private void ColorChanger()
    {
        Color BatteryColor = Color.Lerp(Color.red,Color.green,_currentBattery/_MaxBattery);
        BatteryBar.color = BatteryColor;
    }

    public void BatteryRegen(float BatteryPoints)
    {
        if (_currentBattery < _MaxBattery)
        {
            _currentBattery += BatteryPoints;
        }
    }

    public void BatteryDrainOverTime()
    {
        _currentBattery -= Time.deltaTime;
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
