using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Spawn;
using SumoNS.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SumoNS.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private float spawnInterval = 0.1f;
        [SerializeField] CollectableManager _objectPooling;
        [SerializeField] private Vector3 spawnPos;

        private bool IsSpawn;
        private float _spawnInterval;

        private Rigidbody _characterRigibody;


        private void Start()
        {
            InvokeRepeating("SpawnInvoke",1,1);
        }

     
        private void SpawnInvoke()
        {
            
            var obj = _objectPooling.GetPoolObject();
            if(obj==null)return;
            obj.transform.position = CollectableManager.Instance.SpawnPoint();
            _spawnInterval = 0;
            
        }
    }
}