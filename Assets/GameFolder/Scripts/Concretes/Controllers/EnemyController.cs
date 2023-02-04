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

        [Header("Movement Informations")] [SerializeField]
        float speed = 0;


        public float pushForce = 10f;

        private EnemyAnimation _animation;
        private IPoint _point;
        Rigidbody enemyRb;


        public float characterRadius = 0.5f;
        public LayerMask platformLayer;

        private bool isGrounded;


        private void Awake()
        {
            enemyRb = GetComponent<Rigidbody>();
            _point = GetComponent<IPoint>();
            _animation = new EnemyAnimation(this);
        }

       


        private void FixedUpdate()
        {
            Debug.Log("EnemyCount:"+EnemyManager.Instance._enemyCount);
            IsGroundedControl();
            ConstraintsCheck();

            if (isGrounded)
            {
                FindClosestEnemy();
                MoveTowardsTarget();
                RotateTowardsTarget();
            }
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
                transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);

                speed += 0.01f;
                pushForce += 0.09f;
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

        void MoveTowardsTarget()
        {
            Vector3 direction = (Target.position - transform.position).normalized;

            if (enemyRb.velocity.magnitude < 6) enemyRb.AddForce(direction * speed);
        }

        void RotateTowardsTarget()
        {
            if (Target == null)
            {
                return;
            }

            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        void FindClosestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Collectable");
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
                enemyRb.constraints = RigidbodyConstraints.None;
                Destroy(gameObject, 2);
            }
        }

        private void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemyController(this);
        }
    }
}