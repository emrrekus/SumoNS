using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SumoNS.Abstracts.Movements
{
    public interface IRotation
    {
        // For dynamically moving objects in the rotation
        void MoveRotation(Touch touch, Vector2 touchPosition, Quaternion rotationY,float rotateSpeedModifier);
    }
}
