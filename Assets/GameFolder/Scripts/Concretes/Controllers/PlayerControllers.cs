using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Movements;
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
        private float rotateSpeedModifier = 0.5f;

        private IMover _mover;
        private IRotation _rotation;


        private void Awake()
        {
            _mover = new MoveCharacter(this);
            _rotation = new RotationCharacter(this);
        }

        void Update()
        {
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(speed);
            _rotation.MoveRotation(_touch, touchPosition, rotationY, rotateSpeedModifier);
        }
    }
}