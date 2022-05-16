using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance;
    private int _numberOfPlatesPressed = 0;
    [SerializeField] private GameObject _boss;

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
        if (_numberOfPlatesPressed >= 4)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        _boss.SetActive(true);
    }
}
