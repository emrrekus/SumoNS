using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using SumoNS.Abstracts.Controllers;
using SumoNS.Abstracts.Movements;
using SumoNS.Abstracts.Points;
using SumoNS.Animations;
using SumoNS.Managers;
using SumoNS.Movements;
using UnityEngine;

namespace SumoNS.Controllers
{
    public class PlayerControllers : MonoBehaviour, IEntityController
    {
        [Header("Movement Informations")] [SerializeField]
        float speed = 5;


        [Header("Bounce Informations")] [SerializeField]
        public float pushForce = 0.5f;

        private Touch _touch;
        private Vector2 touchPosition;
        private Quaternion rotationY;
        private float rotateSpeedModifier = 0.3f;
        Vector3 direction;
        float maxSpeed = 2;

        private CharacterAnimation _animation;
        private CinemachineVirtualCamera _playerCamera;

        private Rigidbody _playerRb;

        private IPoint _point;
        private IMover _mover;
        private IRotation _rotation;

        private int _scor;

        public float characterRadius = 0.5f;
        public LayerMask platformLayer;

        private bool isGrounded;
        private bool isDead;

        
        
        private void Awake()
        {
            _playerCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            isGrounded = true;
            _point = GetComponent<IPoint>();
            _playerRb = GetComponent<Rigidbody>();
            _mover = new MoveCharacter(this);
            _rotation = new RotationCharacter(this);
            _animation = new CharacterAnimation(this);
        }


        private void Update()
        {
            if (!isGrounded) _playerCamera.enabled = false;
            direction = _playerRb.transform.forward;
        }

        private void FixedUpdate()
        {
            IsGroundedControl();
            ConstraintsCheck();

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
                _point.TakePoint(100);
                transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
                _playerRb.mass += 0.1f;
            }
            if (other.gameObject.CompareTag("Ground"))
            {
                isDead = true;
                GameManagers.Instance.Lose();
                
               
                
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


        private void IsGroundedControl()
        {
            isGrounded = Physics.CheckSphere(transform.position, characterRadius, platformLayer);
        }

        private void ConstraintsCheck()
        {
            if (!isGrounded) _playerRb.constraints = RigidbodyConstraints.None;
        }
    }
}