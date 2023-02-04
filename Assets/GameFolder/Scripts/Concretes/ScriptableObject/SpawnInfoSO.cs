using System.Collections;
using System.Collections.Generic;
using SumoNS.Controllers;
using UnityEngine;

namespace SumoNS.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner Info",menuName = "Spawner Information/Create New",order = 51)]
    public class SpawnInfoSO : ScriptableObject
    {
        //We hold the enemies that will spawn
        [SerializeField] private EnemyController _enemyPrefab;


        public EnemyController EnemyPrefab => _enemyPrefab;
    }
}
