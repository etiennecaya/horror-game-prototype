using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject FlashLightManager = null;
    public GameObject MainMenuCanvas = null;
    public PlayerController PlayerController = null;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _mainMenuMusic = null;
    [SerializeField] private AudioClip _gameplayMusic = null;

    private void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
   public void StartGame()
   {
        Cursor.lockState = CursorLockMode.Locked;
        _audioSource.Stop();
        _audioSource.clip = _gameplayMusic;
        _audioSource.Play();
        MainMenuCanvas.SetActive(false);
        FlashLightManager.SetActive(true);
        CameraManager.Instance.ActivateGamePlayCamera();
        StartCoroutine(ActivePlayerController());
   }
   public void ExitGame()
   {
       Application.Quit();
   }

   private IEnumerator ActivePlayerController()
   {
       yield return new WaitForSeconds(2);
       PlayerController.ActivateInputs();
   }

   
}
