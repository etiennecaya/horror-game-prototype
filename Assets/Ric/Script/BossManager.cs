using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance;
    private int _numberOfPlatesPressed = 0;
    [SerializeField] private GameObject _boss;
    private bool _BossSpawned = false;
    private NavMeshAgent _agent = null;
    private AudioSource _audiosource = null;

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

    public void PlatePressed()
    {
        _numberOfPlatesPressed ++;
        if (_numberOfPlatesPressed == 4)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        _boss.SetActive(true);
        _audiosource.Play();
        _BossSpawned = true;
    }

    private void Start() 
    {
        _audiosource = GetComponent<AudioSource>();
        _agent = _boss.GetComponent<NavMeshAgent>();
        
    }

    private void Update() 
    {
        if(_agent.enabled == false && _BossSpawned)
        {
            StartCoroutine(LoadEndScene());
        }
        else
        {
            return;
        }
    }

    private IEnumerator LoadEndScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
