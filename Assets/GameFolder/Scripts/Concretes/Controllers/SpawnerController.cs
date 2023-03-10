using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SumoNS.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
       
        [SerializeField] CollectableManager _objectPooling;
        [SerializeField] private Vector3 spawnPos;

        private bool IsSpawn;
       
        private void Start()
        {
            InvokeRepeating("SpawnInvoke",0f,0.01f);
        }

        // We iterate over objects using the object pooling method
        private void SpawnInvoke()
        {
            
            var obj = _objectPooling.GetPoolObject();
            if(obj==null)return;
            obj.transform.position = CollectableManager.Instance.SpawnPoint();
            
            
            
        }
    }
}