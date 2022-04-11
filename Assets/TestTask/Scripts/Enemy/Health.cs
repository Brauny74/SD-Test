using UnityEngine;
using UnityEngine.Events;

namespace TestGame
{
    public class Health : MonoBehaviour
    {
        public int maxHealthPoints;
        private int healthPoints;
        public bool destroyOnDeath;

        public UnityEngine.UI.Image healthBar;

        public UnityEvent OnDeath;

        private EnemyController controller;

        private void Awake()
        {
            controller = GetComponent<EnemyController>();
            healthPoints = maxHealthPoints;
        }

        public void DealDamage(int value)
        {
            if (!controller.engaged)
                return;

            healthPoints -= value;
            UpdateProgressBar();
            if (healthPoints <= 0)
            {
                Die();
            }
        }

        private void UpdateProgressBar()
        {
            if (healthBar == null)
                return;

            healthBar.fillAmount = (float)healthPoints / maxHealthPoints;
        }

        private void Die()
        {
            OnDeath.Invoke();
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}