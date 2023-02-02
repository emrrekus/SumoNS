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
        [SerializeField] private float spawnInterval = 1;

        [SerializeField] CollectableManager _objectPooling;
        [SerializeField] private Vector3 spawnPos;

        private bool IsSpawn;


        private float _spawnInterval;


        private void Start()
        {
            StartCoroutine(nameof(SpawnRoutine));
        }

        private void FixedUpdate()
        {
            IsSpawn = Collectable.IsSpawn;
        }


        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                if (IsSpawn)
                {
                    var obj = _objectPooling.GetPoolObject();
                    obj.transform.position = SpawnPoint();
                    _spawnInterval = 0;
                    yield return new WaitForSeconds(spawnInterval);
                    Collectable.IsSpawn = false;
                    

                }
               
            }
        }


        private Vector3 SpawnPoint()
        {
            spawnPos = new Vector3(Random.Range(-7, 15), 1, Random.Range(23, 0));
            return spawnPos;
        }
    }
}