using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SumoNS.Movements
{
    public class CollactableMove : MonoBehaviour
    {
        private float rotationSpeed = 60f;

        void Start()
        {
            Vector3 randomDirection = Random.onUnitSphere;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, randomDirection);
        }

        void Update()
        {
            transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
        }
    }
}
