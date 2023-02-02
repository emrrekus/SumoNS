using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Movements;
using SumoNS.Controllers;
using UnityEngine;

namespace SumoNS.Movements
{
    public class MoveCharacter : IMover
    {
        private Rigidbody _characterRigibody;
       
        public MoveCharacter(PlayerControllers playerController)
        {
            _characterRigibody = playerController.GetComponent<Rigidbody>();
        }

        public void MoveAction(float speed,Vector3 direction,float maxSpeed)
        {
            if (_characterRigibody.velocity.magnitude < maxSpeed)
            {
                _characterRigibody.AddForce(direction*speed,ForceMode.Force);
            }
            
        }
    }
}