using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SumoNS.Abstracts.Movements
{
    public interface IMover
    {
        void MoveAction(float speed,Vector3 direction,float maxSpeed);

    }
}
