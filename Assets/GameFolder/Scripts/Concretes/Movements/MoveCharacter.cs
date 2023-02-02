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
             _characterRigibody.transform.position += _characterRigibody.transform.forward * speed * Time.deltaTime;
        }
    }
}
