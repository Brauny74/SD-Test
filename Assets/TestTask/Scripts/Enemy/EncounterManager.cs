using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestGame
{
    public class EncounterManager : MonoBehaviour
    {
        private List<EnemyController> enemies;

        public UnityEvent OnAllEnemiesDead;

        private int amountOfEnemies;
        public bool engaged;

        public void SetEngaged(bool value)
        {
            foreach (EnemyController enemy in enemies)
            {
                enemy.SetEngaged(value);
            }
        }

        public void StartEncounter()
        {
            SetEngaged(true);
        }

        public void OnEnable()
        {            
            enemies = new List<EnemyController>(GetComponentsInChildren<EnemyController>());
            amountOfEnemies = enemies.Count;
            foreach (EnemyController enemy in enemies)
            {
                enemy.health.OnDeath.AddListener(SubstractEnemy);
                enemy.SetEngaged(engaged);
            }
        }

        public void SubstractEnemy()
        {
            amountOfEnemies--;
            if (amountOfEnemies == 0)
            {
                OnAllEnemiesDead.Invoke();
            }
        }
    }
}