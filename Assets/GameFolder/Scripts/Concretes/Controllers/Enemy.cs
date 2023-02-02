using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SumoNS
{
    public class Enemy : MonoBehaviour
    {
        public float speed = 100f;
        private Rigidbody enemyRb;
        private GameObject player;

        private void Awake()
        {
            enemyRb = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            enemyRb.AddForce((player.transform.position-transform.position).normalized*speed);
        }
       
    }
}
