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

        private void Awake()
        {
            SingletonThisObject(this);
            _enemies = new List<EnemyController>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }
        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }
    }
}
