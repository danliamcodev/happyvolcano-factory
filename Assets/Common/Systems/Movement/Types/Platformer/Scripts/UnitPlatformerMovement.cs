using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Movement
{
    public class UnitPlatformerMovement : AUnitMovement
    {
        float _xDirection = 0;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 velocity = new Vector2(_xDirection * _movementSped, _targetBody.velocity.y);
            _targetBody.velocity = velocity;
        }

        public override void Move(Vector2 p_direction)
        {

        }

        public override void OnInputStarted(Vector2 p_direction)
        {

        }

        public override void OnInputPerformed(Vector2 p_direction)
        {
            _xDirection = p_direction.x;
        }

        public override void OnInputCancelled(Vector2 p_direction)
        {

        }
    }
}