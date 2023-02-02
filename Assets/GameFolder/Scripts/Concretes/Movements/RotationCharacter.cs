using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Movements;
using SumoNS.Controllers;
using UnityEngine;

namespace SumoNS.Movements
{
    public class RotationCharacter : IRotation
    {
        private Rigidbody _characterRigibody;

        public RotationCharacter(PlayerControllers playerController)
        {
            _characterRigibody = playerController.GetComponent<Rigidbody>();
        }
        
        public void MoveRotation(Touch touch, Vector2 touchPosition, Quaternion rotationY,float rotateSpeedModifier)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                       
                    rotationY=Quaternion.Euler(0f,-touch.deltaPosition.x*rotateSpeedModifier,0f);
                    _characterRigibody.transform.rotation = rotationY * _characterRigibody.transform.rotation;
                }
            }
        }
    }
}
