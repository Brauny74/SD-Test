using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletMovement : MonoBehaviour
    {
        public float Speed;

        public enum Directions { Forward, Backward, Left, Right }
        public Directions direction;

        Rigidbody _rBody;

        private void Awake()
        {
            _rBody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _rBody.velocity = Vector3.zero;
            _rBody.angularVelocity = Vector3.zero;
        }

        private void FixedUpdate()
        {
            _rBody.AddRelativeForce(GetDirectionVector() * Speed, ForceMode.Force);
        }

        private Vector3 GetDirectionVector()
        {
            switch (direction)
            {
                case Directions.Forward:
                    return Vector3.forward;
                case Directions.Backward:
                    return Vector3.back;
                case Directions.Left:
                    return Vector3.left;
                case Directions.Right:
                    return Vector3.right;
                default:
                    return Vector3.zero;
            }
        }
    }
}