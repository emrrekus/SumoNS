using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Managers;
using SumoNS.ScriptableObjects;
using UnityEngine;

namespace SumoNS.Controllers
{
    public class EnemySpawnerController : MonoBehaviour
    {
        [SerializeField] private SpawnInfoSO _spawnInfo;

        
        private void Awake()
        {
            Spawn();
        }
        // We Instatiate the enemy object that it has taken from Scriptable to the spawn point

        private void Spawn()
        {
            
           EnemyController enemyController= Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);
          EnemyManager.Instance.AddEnemyController(enemyController);
           
        }
    }
}
