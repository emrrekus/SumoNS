using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Controllers;
using SumoNS.Abstracts.Movements;
using SumoNS.Animations;
using SumoNS.Managers;
using SumoNS.Movements;
using UnityEngine;

namespace SumoNS.Controllers
{
    public class PlayerControllers : MonoBehaviour
    {
        [Header("Movement Informations")] [SerializeField]
        float speed = 5;
        Vector3 direction;
        float maxSpeed = 2;

        [Header("Bounce Informations")] [SerializeField]
        public float pushForce = 0.5f;

        private Touch _touch;
        private Vector2 touchPosition;
        private Quaternion rotationY;
        private float rotateSpeedModifier = 0.3f;

        private CharacterAnimation _animation;

        private Rigidbody _playerRb;


        private IMover _mover;
        private IRotation _rotation;

        private bool IsRun;
        public float moveSpeed = 1;


        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody>();
            IsRun = true;
            _mover = new MoveCharacter(this);
            _rotation = new RotationCharacter(this);
            _animation = new CharacterAnimation(this);
        }

        private void Update()
        {
            direction = _playerRb.transform.forward;
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(speed, direction, maxSpeed);
            _rotation.MoveRotation(_touch, touchPosition, rotationY, rotateSpeedModifier);
        }

        private void LateUpdate()
        {
            _animation.MoveAnimations(maxSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectable"))
            {
                other.gameObject.SetActive(false);
                CollectableManager.Instance.IsSpawn(true);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody otherBody = collision.collider.attachedRigidbody;

            if (otherBody == null)
            {
                return;
            }

            Vector3 pushDirection = collision.contacts[0].point - transform.position;
            pushDirection = pushDirection.normalized;
            
            otherBody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            
        }
      


       
    }
}