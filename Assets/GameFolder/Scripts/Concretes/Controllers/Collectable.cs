using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SumoNS
{
    public class Collectable : MonoBehaviour
    {

        public static bool IsSpawn;

        private void Awake()
        {
            IsSpawn = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Collectable"))
            {
                Debug.Log("Değdi");
                gameObject.SetActive(false);
                IsSpawn = true;
            }
        }
        
    }
    
}
