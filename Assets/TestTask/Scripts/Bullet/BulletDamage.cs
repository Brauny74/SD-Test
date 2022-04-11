using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class BulletDamage : MonoBehaviour
    {
        [Tooltip("A tag used by the object launching this bullet and ignored on launch by it.")]
        public string launcherTag;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag != launcherTag)
                gameObject.SetActive(false);
        }
    }
}