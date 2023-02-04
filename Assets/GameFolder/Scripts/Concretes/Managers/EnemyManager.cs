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
       
        public List<Transform> Targets { get; private set; }

        public List<EnemyController> Enemies => _enemies;

        public int _enemyCount => _enemies.Count+1;
      

        private void Awake()
        {
            SingletonThisObject(this);
            _enemies = new List<EnemyController>();
            Targets = new List<Transform>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
           
            _enemies.Add(enemyController);
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].name = "Enemy" + (i + 1);
            }
            
        }
        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }
    }
}
