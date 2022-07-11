using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(EnemyMovement))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        protected string PlayerTag;

        [SerializeField]
        protected RagdollController ragdollController;

        public EnemyMovement movement;
        public Health health;

        public bool engaged;        

        public void SetEngaged(bool value)
        {
            engaged = value;
            if (value)
                movement.Move();
            else
                movement.Stop();
        }

        private void Awake()
        {
            movement = GetComponent<EnemyMovement>();
            health = GetComponent<Health>();
            ragdollController.SetCollidersActive(false);
        }

        public void LoseGame()
        {
            GameManager.Instance.LoseGame();
        }

        public void Die()
        {
            engaged = false;
            Ragdoll();
        }

        private void Ragdoll()
        {
            ragdollController.SetCollidersActive(true);
            ragdollController.SetAnimatorActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
                if(engaged)
                    LoseGame();
        }
    }
}