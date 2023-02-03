using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SumoNS
{
    public class NavMeshDeneme : MonoBehaviour
    {
        public Transform target;
        private NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            FindClosestEnemy();
            agent.SetDestination(target.position);
        }

        void FindClosestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float closestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;
            Vector3 currentPosition = transform.position;
            foreach (GameObject enemy in enemies)
            {
                Vector3 directionToEnemy = enemy.transform.position - currentPosition;
                float distanceToEnemy = directionToEnemy.magnitude;
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy != null)
            {
                target = closestEnemy.transform;
            }
        }
    }
}