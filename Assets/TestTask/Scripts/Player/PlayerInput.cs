using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{    
    [RequireComponent(typeof(PlayerShoot))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Layers, which when touched, return direction for bullet. Should be everything, BUT player and projectile layer.")]
        protected LayerMask layersUsedForShooting;

        protected PlayerShoot shoot;

        protected enum InputStates { Idle, Pressed, Released }
        protected InputStates currentInputState;

        private void Awake()
        {
            currentInputState = InputStates.Idle;
            shoot = GetComponent<PlayerShoot>();
        }

        // Update is called once per frame
        void Update()
        {
            ProcessInput();
        }

        /// <summary>
        /// Checks if the screen is pressed or left mouse button is pressed
        /// </summary>
        /// <returns>true if the finger on screen or left mouse button is pressed, otherwise false</returns>
        private bool IsScreenPressed()
        {
            return Input.GetMouseButton(0) || Input.touchCount > 0;
        }

        /// <summary>
        /// Returns the screen position of the touch, or the screen position of mouse, if there are no touches
        /// </summary>
        /// <returns>Vector2 of the touch or mouse position.</returns>
        private Vector2 GetTouchPosition()
        {
            if (Input.touchCount > 0)
                return Input.GetTouch(0).position;
            else
                return Input.mousePosition;
        }

        /// <summary>
        /// Get touch or click position in world
        /// </summary>
        /// <returns></returns>
        private Vector3 GetTouchInWorldPosition()
        {
            Vector3 screenPos = GetTouchPosition();
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layersUsedForShooting))
            {
                return hit.point;
            }
            return Vector3.zero;
        }

        private void ProcessInput()
        {
            switch (currentInputState)
            {
                case InputStates.Idle:
                    ProcessIdleState();
                    break;
                case InputStates.Pressed:
                    ProcessPressedState();
                    break;
                case InputStates.Released:
                    ProcessReleasedState();
                    break;
            }
        }

        private void ProcessIdleState()
        {
            if (IsScreenPressed())
            {
                currentInputState = InputStates.Pressed;
            }
        }

        private void ProcessPressedState()
        {
            if (!IsScreenPressed())
            {
                currentInputState = InputStates.Released;
            }
        }

        private void ProcessReleasedState()
        {
            if(!GameManager.Instance.paused)
                shoot.Shoot(GetTouchInWorldPosition());

            currentInputState = InputStates.Idle;
        }
    }
}