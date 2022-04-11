using UnityEngine;
using UnityEngine.AI;

namespace TestGame
{
    public class EnemyMovement : Movement
    {
        private EnemyController controller;

        protected override void Awake()
        {
            base.Awake();
            controller = GetComponent<EnemyController>();
        }

        public void Move()
        {
            MoveTo(GameManager.Instance.GetPlayerPosition());
        }
    }
}