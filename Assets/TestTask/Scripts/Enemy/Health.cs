using UnityEngine;
using UnityEngine.Events;

namespace TestGame
{
    [RequireComponent(typeof(EnemyController))]
    public class Health : MonoBehaviour
    {
        [SerializeField]
        protected int maxHealthPoints;
        protected int healthPoints;

        [SerializeField]
        protected bool destroyOnDeath;

        [SerializeField]
        protected Canvas healthBarCanvas;

        [SerializeField]
        protected UnityEngine.UI.Image healthBar;

        public UnityEvent OnDeath;

        protected EnemyController controller;

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
            controller.Die();
            healthBarCanvas.gameObject.SetActive(false);
        }
    }
}