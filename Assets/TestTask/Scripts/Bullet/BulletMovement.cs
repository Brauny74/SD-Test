using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField]
        protected float speed;

        public enum Directions { Forward, Backward, Left, Right }
        public Directions direction;

        protected Rigidbody rBody;

        private void Awake()
        {
            rBody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            rBody.velocity = Vector3.zero;
            rBody.angularVelocity = Vector3.zero;
        }

        private void FixedUpdate()
        {
            rBody.AddRelativeForce(GetDirectionVector() * speed, ForceMode.Force);
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