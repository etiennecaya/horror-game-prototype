using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public GameObject MainMenuCamera = null;
    public GameObject GameplayCamera = null;

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

    public void ActivateGamePlayCamera()
    {
        MainMenuCamera.SetActive(false);
        GameplayCamera.SetActive(true);
    }
}
