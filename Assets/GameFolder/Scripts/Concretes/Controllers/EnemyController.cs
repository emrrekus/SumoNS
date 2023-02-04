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

        //The propulsion of the enemy we use at the time of the collision
        [SerializeField] float pushForce = 10f;

        private EnemyAnimation _animation;
        private IPoint _point;
        Rigidbody enemyRb;

        //To check if the enemy is on the ground
        [SerializeField] float characterRadius = 0.5f;
        [SerializeField] LayerMask platformLayer;

        private bool isGrounded;
        private bool isDead;


        private void Awake()
        {
            enemyRb = GetComponent<Rigidbody>();
            _point = GetComponent<IPoint>();
            _animation = new EnemyAnimation(this);
        }

        


        private void FixedUpdate()
        {
            //We check whether the character is on the ground and turn on the milling machine of the y position according to the situation.
            GroundedAndConstraintControl();
            if (isGrounded)
            {
                // We find the closest object to the Enemy and turn towards it and make it move forward.
                TowardsClosestControl();
            }
        }

        private void LateUpdate()
        {
            _animation.MoveAnimations(1f);
        }

        //Here, if the enemy has contacted the collectable, we update the enemy's score,physics,scor text and check the colletable spawn process.
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

            if (other.gameObject.CompareTag("Ground"))
            {
                isDead = true;
            }
        }

        //We control the collision of the enemy and the player collider, if there is a collision, we push the enemy with the force as much as the push force.
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

        // We find the closest object to the Enemy and turn towards it and make it move forward.
        void TowardsClosestControl()
        {
            MoveTowardsTarget();
            RotateTowardsTarget();
            FindClosestEnemy();
        }
        
        //We find the direction the enemy will move
        void MoveTowardsTarget()
        {
            if (Target == null)
            {
                return;
            }
            Vector3 direction = (Target.position - transform.position).normalized;

            if (enemyRb.velocity.magnitude < 6) enemyRb.AddForce(direction * speed);
        }

        //We find the rotation the enemy will move
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

        // Enemy to find the closest object
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

        //We check whether the character is on the ground and turn on the milling machine of the y position according to the situation.

        private void GroundedAndConstraintControl()
        {
            IsGroundedControl();
            ConstraintsCheck();
        }
        //We are checking if the enemy is on the platform
        private void IsGroundedControl()
        {
            isGrounded = Physics.CheckSphere(transform.position, characterRadius, platformLayer);
        }
        // If the character is not on the platform, we open the cutter of the y position
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