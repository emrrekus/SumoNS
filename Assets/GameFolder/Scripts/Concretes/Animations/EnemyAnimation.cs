using System.Collections;
using System.Collections.Generic;
using SumoNS.Controllers;
using UnityEngine;

namespace SumoNS.Animations
{
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _animator;

        public EnemyAnimation(EnemyController enemyController)
        {
            _animator = enemyController.GetComponentInChildren<Animator>();
        }

        public void MoveAnimations(float moveSpeed)
        {
            
            _animator.SetFloat("moveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }
    }
}
