using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Utitiles;
using SumoNS.Controllers;
using UnityEngine;

namespace SumoNS.Managers
{
    public class EnemyManager : SingletonMBObject<EnemyManager>
    {
        [SerializeField] private List<EnemyController> _enemies;

        public List<EnemyController> Enemies => _enemies;

        // Check the length of the enemy list.
        public int _enemyCount => _enemies.Count + 1;


        private void Awake()
        {
            SingletonThisObject(this);
            _enemies = new List<EnemyController>();
        }
        // We add the created enemies to the list and collect them under this parent
        // We change the names of the formed enemies
        public void AddEnemyController(EnemyController enemyController)
        {
            // We add the created enemies to the list and collect them under this parent
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
            
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].name = "Enemy" + (i + 1);
            }
        }

        // We remove the destroyed enemy from the list
        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }
    }
}