using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SumoNS.Abstracts.Movements
{
    public interface IRotation
    {
        void MoveRotation(Touch touch, Vector2 touchPosition, Quaternion rotationY,float rotateSpeedModifier);
    }
}
