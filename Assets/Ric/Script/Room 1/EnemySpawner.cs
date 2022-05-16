using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField]private NavMeshAgent _agent;
   [SerializeField] GameObject[] _enemiesToSpawnRoom1;
   //private bool _canSpawnEnemies;

   private void Update() 
   {
       if (_agent.enabled == false)
       {
           SpawnEnemies();
       }
   }

   private void SpawnEnemies()
   {
       for (int i = 0; i < _enemiesToSpawnRoom1.Length; i++)
       {
           _enemiesToSpawnRoom1[i].SetActive(true);
       }
   }
}
