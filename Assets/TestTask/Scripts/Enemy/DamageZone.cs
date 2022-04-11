using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestGame
{
    public class DamageZone : MonoBehaviour
    {
        public Health healthToDamage;
        public int damageFromBullet;
        public string bulletTag = "Projectile";

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == bulletTag)
            {
                healthToDamage.DealDamage(damageFromBullet);
                other.gameObject.SetActive(false);
            }
        }
    }
}