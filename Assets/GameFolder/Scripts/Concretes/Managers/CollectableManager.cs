using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Utitiles;
using SumoNS.Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SumoNS.Managers
{
    public class CollectableManager : SingletonMBObject<CollectableManager>
    {
        private Queue<GameObject> _pooledObject;
        [SerializeField] private GameObject objectPrefab;
        [SerializeField] private int poolSize;
        private Vector3 spawnPos;
        private bool _IsSpawn;

        public bool Spawn => _IsSpawn;


        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
         InitalizePool();
        }

        //Object Pooling
        private void InitalizePool()
        {
            _pooledObject = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(objectPrefab,SpawnPoint(),Quaternion.identity);
                obj.transform.rotation = Quaternion.Euler(0, 0, 90);
;                obj.SetActive(true);
                _pooledObject.Enqueue(obj);
            }
        }

        public GameObject GetPoolObject()
        {
            if (_IsSpawn)
            {
                GameObject obj = _pooledObject.Dequeue();
                obj.SetActive(true);
                _pooledObject.Enqueue(obj);
                _IsSpawn = false;
                return obj;
                
            }
            else
            {
                return null;
            }
           
        }
        //we make the object spawn in random positions

        public Vector3 SpawnPoint()
        {
            
            spawnPos = new Vector3(Random.Range(-3.6f, 15f), 2.5f, Random.Range(19, 0.8f));
            return spawnPos;
        }
        //We check whether the object can spawn or not.
        public void IsSpawn(bool spawn)
        {
            _IsSpawn = spawn;
        }

       
    }
}