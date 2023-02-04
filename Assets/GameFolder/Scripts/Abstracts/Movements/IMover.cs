using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SumoNS.Abstracts.Movements
{
    public interface IMover
    {
        // For dynamically moving objects in the direction
        void MoveAction(float speed,Vector3 direction,float maxSpeed);

    }
}
