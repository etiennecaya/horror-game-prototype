using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSpawn : MonoBehaviour
{
    private Vector3 _lastCheckpoint;
    [SerializeField] private GameObject[] _lesObjetsARespawnQuandOnMeurt;
    private CharacterController _playerController;
    [SerializeField] private Animator _animator;

    private void Start() 
    {
        _playerController = GetComponent<CharacterController>();
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
        UIManager.Instance.BatteryRegen(100);
        UIManager.Instance.GainHealth(3);
    }

    private void TeleportCharacterToLastCheckpoint()
    {
        _playerController.enabled = false;
        transform.position = _lastCheckpoint;
        StartCoroutine(WakeUp());
    }

    public IEnumerator WakeUp()
    {
        _animator.Play("Respawn");
        yield return new WaitForSeconds(5.5f);
        _playerController.enabled = true;

    }
}
