using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Controllers;
using SumoNS.Abstracts.Movements;
using SumoNS.Abstracts.Points;
using SumoNS.Animations;
using SumoNS.Managers;
using SumoNS.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace SumoNS.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform Target;

        private IPoint _point;
        private IMover _mover;
        private EnemyAnimation _animation;
        public float pushForce = 10f;

        
         NavMeshAgent _navMeshAgent;
         Rigidbody _enemyRb;
        
        
        public float characterRadius = 0.5f;
        public LayerMask platformLayer;

        private bool isGrounded;
        private bool isWalk;

        private void Awake()
        {
            
            _enemyRb = GetComponent<Rigidbody>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _point = GetComponent<IPoint>();
            _animation = new EnemyAnimation(this);
            _mover = new MoveWithNavMesh(this);
        }

        private void Start()
        {
          
        }

        
       

        private void FixedUpdate()
        {
            IsGroundedControl();
            ConstraintsCheck();
            FindClosestEnemy();
            if(!isWalk)_mover.MoveAction(10f, Target.transform.position, 10f);
            
           
            
        }

        private void LateUpdate()
        {
            _animation.MoveAnimations(1f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectable"))
            {
                other.gameObject.SetActive(false);
                CollectableManager.Instance.IsSpawn(true);
                _point.TakePoint(100);
                
            }

            if (other.gameObject.CompareTag("Close"))
            {
                Debug.Log("Değdi");
                isWalk = false;
                _navMeshAgent.enabled = false;
            }
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody otherBody = collision.collider.attachedRigidbody;

            if (otherBody != null)
            {
                Vector3 pushDirection = collision.contacts[0].point - transform.position;
                pushDirection = pushDirection.normalized;

                otherBody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }

        }
        void FindClosestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float closestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;
            Vector3 currentPosition = transform.position;
            foreach (GameObject enemy in enemies)
            {
                if (enemy == gameObject)
                {
                    continue;
                }
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
                Target = closestEnemy.transform;
            }
        }
        private void IsGroundedControl()
        {
            isGrounded = Physics.CheckSphere(transform.position, characterRadius, platformLayer);
        }

        private void ConstraintsCheck()
        {
            if (!isGrounded)
            {
                _enemyRb.constraints = RigidbodyConstraints.None;
                Destroy(gameObject);
            }
        }

        /*private void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemyController(this);
        }*/
    }
}