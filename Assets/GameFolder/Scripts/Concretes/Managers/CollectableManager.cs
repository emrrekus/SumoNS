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
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private int poolSize;
        private Vector3 spawnPos;


        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitalizePool();
        }

        private void InitalizePool()
        {
            _pooledObject = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(_gameObject, SpawnPoint(), Quaternion.identity);
                obj.SetActive(true);
                _pooledObject.Enqueue(obj);
            }
        }

        public GameObject GetPoolObject()
        {
            GameObject obj = _pooledObject.Dequeue();
            obj.SetActive(true);
            _pooledObject.Enqueue(obj);

            return obj;
        }

        private Vector3 SpawnPoint()
        {
            spawnPos = new Vector3(Random.Range(-7, 15), 1, Random.Range(23, 0));
            return spawnPos;
        }
    }
}