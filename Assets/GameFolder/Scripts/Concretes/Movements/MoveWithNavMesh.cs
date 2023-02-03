using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Controllers;
using SumoNS.Abstracts.Movements;
using SumoNS.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace SumoNS.Movements
{
    public class MoveWithNavMesh : IMover
    {
        
        private NavMeshAgent _navMeshAgent;
       

        public MoveWithNavMesh(IEntityController entityController)
        {
            
            _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
        }
        public void MoveAction(float speed, Vector3 direction, float maxSpeed)
        {
            _navMeshAgent.SetDestination(direction);
            
        }
    }
}
