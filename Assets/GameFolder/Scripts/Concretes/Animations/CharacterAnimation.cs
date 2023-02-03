using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Controllers;
using SumoNS.Controllers;
using UnityEngine;

namespace SumoNS.Animations
{
    public class CharacterAnimation
    {
        private Animator _animator;

        public CharacterAnimation(PlayerControllers entity)
        {
            _animator = entity.GetComponentInChildren<Animator>();
        }

        public void MoveAnimations(float moveSpeed)
        {
            
            _animator.SetFloat("moveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }
    }
}
