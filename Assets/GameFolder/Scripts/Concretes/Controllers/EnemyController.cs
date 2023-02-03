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

namespace SumoNS.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        private IPoint _point;
        private IMover _mover;
        private EnemyAnimation _animation;
        public float pushForce = 0.5f;

        
       
        private LayerMask platformLayer;
        
        

        private void Awake()
        {

            _point = GetComponent<IPoint>();
            _animation = new EnemyAnimation(this);
            _mover = new MoveWithNavMesh(this);
        }

       

        private void FixedUpdate()
        {
           
            _mover.MoveAction(10f, _playerPrefab.transform.position, 10f);
            
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
      
    }
}