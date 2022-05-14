using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
   public static FlashlightManager Instance;
   public GameObject LightCone = null;
   private AudioSource _audiosource = null;
   public int Battery = 1;
   public int MaxBattery = 1;
   public float CurrentTime = 1f;
   public bool CountDown = false;
   
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

    public void PlayFlashlightSound()
    {
        _audiosource.Play();
    }

    public void BatteryDrainOverTime()
    {
        
    }

    private void Update() 
    {
        CurrentTime = CountDown ? CurrentTime -= Time.deltaTime : CurrentTime += Time.deltaTime;
    }
}
