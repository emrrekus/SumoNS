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

        public void MoveAction(float speed)
        {
            Vector3 direction = _characterRigibody.transform.forward;
             _characterRigibody.transform.position += _characterRigibody.transform.forward * speed * Time.deltaTime;

            // _characterRigibody.AddForce(direction*speed*Time.deltaTime,ForceMode.Impulse);
            //  _characterRigibody.AddRelativeForce(direction*speed,ForceMode.Force);

            
            _characterRigibody.velocity = direction * speed;
        }
    }
}