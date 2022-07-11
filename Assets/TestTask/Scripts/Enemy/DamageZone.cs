using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestGame
{
    public class DamageZone : MonoBehaviour
    {
        public Health healthToDamage;
        [SerializeField]
        protected int damageFromBullet;
        [SerializeField]
        protected string bulletTag = "Projectile";

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == bulletTag)
            {
                healthToDamage.DealDamage(damageFromBullet);                
            }
        }
    }
}