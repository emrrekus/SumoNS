using System.Collections;
using System.Collections.Generic;
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

        public void MoveAnimations(bool Run,float moveSpeed)
        {
            _animator.SetBool("IsRun", Run);
            _animator.SetFloat("moveSpeed",moveSpeed);
        }
    }
}
