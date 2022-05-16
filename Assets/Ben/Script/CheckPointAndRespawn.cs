using UnityEngine;

public class CheckPointAndRespawn : MonoBehaviour
{
    private Vector3 _lastCheckpoint;
    [SerializeField]
    private GameObject[] _lesObjetsARespawnQuandOnMeurt;
    public bool Debug = false;
    private CharacterController _playerController;


    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            _lastCheckpoint = other.transform.position;
        }
    }

    public void Respawn()
    {
        ReactivateCollectedItems();
        RegenerateHealthAndBattery();
        TeleportCharacterToLastCheckpoint();
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
        UIManager.Instance.PlayerCurrentHealth = UIManager.Instance.PlayerMaxHealth;
        UIManager.Instance._currentBattery = UIManager.Instance._MaxBattery;
    }

    private void TeleportCharacterToLastCheckpoint()
    {
        _playerController.enabled = false;
        transform.position = _lastCheckpoint;
        _playerController.enabled = true;
    }
}
