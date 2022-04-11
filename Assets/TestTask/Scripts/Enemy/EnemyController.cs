using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class EnemyController : MonoBehaviour
    {        
        public EnemyMovement movement;
        public Health health;
        public GameObject ragdollToInstantiate;

        public bool engaged;        

        public void SetEngaged(bool value)
        {
            engaged = value;
            if (value)
                movement.Move();
            else
                movement.Stop();
        }

        public bool IsEngaged()
        {
            return engaged;
        }

        private void Awake()
        {
            movement = GetComponent<EnemyMovement>();
            health = GetComponent<Health>();
        }

        public void LoseGame()
        {
            GameManager.Instance.LoseGame();
        }

        public void Ragdoll()
        {
            GameObject ragdoll = Instantiate(ragdollToInstantiate);
            ragdoll.transform.position = transform.position;
            ragdoll.transform.rotation = transform.rotation;
        }
    }
}