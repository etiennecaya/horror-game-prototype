using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSpawn : MonoBehaviour
{
    private Vector3 _lastCheckpoint;
    [SerializeField] private GameObject[] _lesObjetsARespawnQuandOnMeurt;
    private PlayerController _playerController;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHurtBox _hurtBox;

    private void Start() 
    {
        _playerController = GetComponent<PlayerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            _lastCheckpoint = other.transform.position;
        }
    }

    public IEnumerator Respawn()
    {
        _hurtBox.transform.localScale = Vector3.zero;
        _animator.Play("Defeated");
        if (_playerController.FlashLightOn)
        {
            _playerController.FlashLightOn = false;
            _playerController.TurnFlashLightOn();
        }
        yield return new WaitForSeconds(2.5f);
        //ReactivateCollectedItems();
        TeleportCharacterToLastCheckpoint();
        RegenerateHealthAndBattery();
    }
    private void ReactivateCollectedItems()
    {
        for (int i = 0; i < _lesObjetsARespawnQuandOnMeurt.Length; i++)
        {
            _lesObjetsARespawnQuandOnMeurt[i].SetActive(true);
        }
    }

    private void RegenerateHealthAndBattery()
    {
        UIManager.Instance.BatteryRegen(UIManager.Instance._MaxBattery);
        UIManager.Instance.GainHealth(3);
    }

    private void TeleportCharacterToLastCheckpoint()
    {
        _playerController.GetComponent<CharacterController>().enabled = false;
        transform.position = _lastCheckpoint;
        _playerController._rawInputMovement = Vector3.zero;
        StartCoroutine(WakeUp());
    }

    public IEnumerator WakeUp()
    {
        _hurtBox.transform.localScale = Vector3.one;
        _animator.Play("Respawn");
        yield return new WaitForSeconds(5f);
        _playerController.GetComponent<CharacterController>().enabled = true;

    }
}
