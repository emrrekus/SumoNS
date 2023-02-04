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
using TMPro;
using UnityEngine;

namespace SumoNS.Controllers
{
    public class PlayerControllers : MonoBehaviour, IEntityController
    {
        //Player Speed
        [Header("Movement Informations")] [SerializeField]
        private float speed;

        //The propulsion of the character we use at the time of the collision
        [Header("Bounce Informations")] [SerializeField]
        private float pushForce;

        Rigidbody _playerRb;
        private IPoint _point;
        private IMover _mover;
        private IRotation _rotation;

        //The text we use to show the score in the collectabs collected by the character
        [SerializeField] TMP_Text _pointText;

        //To check if the character is on the ground
        [SerializeField] float characterRadius = 0.5f;
        [SerializeField] LayerMask platformLayer;

        //We use it to control the momentum of the character
        float maxSpeed = 2;

        private CharacterAnimation _animation;

        //To disable camera control after character dies
        private CinemachineVirtualCamera _playerCamera;

        //For character touch control
        private Touch _touch;
        private Vector2 touchPosition;
        private Quaternion rotationY;
        private float rotateSpeedModifier = 0.3f;


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


        private void FixedUpdate()
        {
            //We check whether the character is on the ground and turn on the milling machine of the y position according to the situation.
            GroundedAndConstraintControl();
            //Character's actions
            PlayerMover();
            // If only the player is left on the stage, win UI comes
            if(EnemyManager.Instance._enemyCount<2)GameManager.Instance.Win();
        }

        private void LateUpdate()
        {
            //Animation control of the character
            _animation.MoveAnimations(1);
        }
        
        //Here, if the character has contacted the collectable, we update the character's score,physics,scor text and check the colletable spawn process.
        // If the player leaves the platform, he is dead, by checking this, we return the lose UI screen
        private void OnTriggerEnter(Collider other)
        {
            

            if (other.gameObject.CompareTag("Collectable"))
            {
                _pointText.gameObject.SetActive(true);
                Invoke("DeactivateText", 1f);
                other.gameObject.SetActive(false);
                CollectableManager.Instance.IsSpawn(true);
                _point.TakePoint(100);
                transform.localScale += new Vector3(0.08f, 0.08f, 0.08f);
                pushForce += 0.05f;
            }

           

            if (other.gameObject.CompareTag("Ground"))
            {
                isDead = true;

                GameManager.Instance.Lose();
            }
        }

        //We control the collision of the player and the enemy collider, if there is a collision, we push the enemy with the force as much as the push force.
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

        private void PlayerMover()
        {
            _mover.MoveAction(speed, _playerRb.transform.forward, maxSpeed);
            _rotation.MoveRotation(_touch, touchPosition, rotationY, rotateSpeedModifier);
        }

        private void GroundedAndConstraintControl()
        {
            DeactivateCamera();
            IsGroundedControl();
            ConstraintsCheck();
        }
        //We are checking if the character is on the platform
        private void IsGroundedControl()
        {
            isGrounded = Physics.CheckSphere(transform.position, characterRadius, platformLayer);
        }
        // If the character is not on the platform, we open the cutter of the y position
        private void ConstraintsCheck()
        {
            if (!isGrounded) _playerRb.constraints = RigidbodyConstraints.None;
        }
        // After the character colletable touches, we false the text that appears on the character
        private void DeactivateText()
        {
           

            _pointText.gameObject.SetActive(false);
        }

        //If the player is dead, we are doing ground control and following the camera to false
        private void DeactivateCamera()
        {
            if (!isGrounded) _playerCamera.enabled = false;
        }
    }
}