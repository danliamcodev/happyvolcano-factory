using SickLab.Jump;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Jump.Platformer
{
    public class UnitPlatformerJump : AUnitJump
    {
        public override void Jump(float p_value)
        {
            Vector2 velocity = new Vector2(_targetBody.velocity.x, p_value * _jumpForce);
            _targetBody.velocity = velocity;
            base.Jump(p_value);
        }

        public override void OnInputCanceled(float p_value)
        {

        }

        public override void OnInputStarted(float p_value)
        {

        }
    }
}