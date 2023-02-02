using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Movements;
using SumoNS.Animations;
using SumoNS.Movements;
using UnityEngine;

namespace SumoNS.Controllers
{
    public class PlayerControllers : MonoBehaviour
    {
        [Header("Movement Informations")] [SerializeField]
        float speed = 3;

        private Touch _touch;
        private Vector2 touchPosition;
        private Quaternion rotationY;
        private float rotateSpeedModifier = 0.3f;
        
        private CharacterAnimation _animation;
       

        private IMover _mover;
        private IRotation _rotation;

        private bool IsRun;
        private float moveSpeed = 1;

        

        private void Awake()
        {
            IsRun = true;
            _mover = new MoveCharacter(this);
            _rotation = new RotationCharacter(this);
            _animation = new CharacterAnimation(this);
        }

       

        private void FixedUpdate()
        {
            _mover.MoveAction(speed);
            _rotation.MoveRotation(_touch, touchPosition, rotationY, rotateSpeedModifier);
        }

        private void LateUpdate()
        {
            _animation.MoveAnimations(IsRun,1);
        }

       
    }
}