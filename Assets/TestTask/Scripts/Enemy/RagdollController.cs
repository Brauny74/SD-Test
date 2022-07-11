using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField]
        protected Animator ragdollAnimator;

        protected Collider[] ragdollColliders;

        private void Awake()
        {
            ragdollColliders = GetComponentsInChildren<Collider>();
        }

        public void SetCollidersActive(bool value)
        {
            foreach (Collider c in ragdollColliders)
            {
                c.enabled = value;
            }
        }

        public void SetAnimatorActive(bool value)
        { 
            ragdollAnimator.enabled = value;
        }
    }
}