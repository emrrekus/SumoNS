using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Movements;
using UnityEngine;

namespace SumoNS.Controllers
{
    public class PlayerControllers : MonoBehaviour
    {
            private Touch _touch;
            private Vector2 touchPosition;
            private Quaternion rotationY;
            public float speed = 3;
            private float rotateSpeedModifier = 0.5f;
            private IMover _mover;


            private void Awake()
            {
                
            }

            void Update()
            {
                transform.position += -transform.forward * speed * Time.deltaTime;
        
                if (Input.touchCount > 0)
                {
                    _touch = Input.GetTouch(0);
                    if (_touch.phase == TouchPhase.Moved)
                    {
                       
                            rotationY=Quaternion.Euler(0f,-_touch.deltaPosition.x*rotateSpeedModifier,0f);
                            transform.rotation = rotationY * transform.rotation;
                    }
                }
            }

    }
}
