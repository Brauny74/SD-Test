using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    [RequireComponent(typeof(TestTools.Poolable))]
    public class BulletDamage : MonoBehaviour
    {
        TestTools.Poolable poolable;

        [SerializeField]
        [Tooltip("Tags used by the object this bullet can collide with.")]
        protected List<string> tagsToCollide;


        private void Awake()
        {
            poolable = GetComponent<TestTools.Poolable>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            foreach (string tagToCollide in tagsToCollide)
            {
                if (collision.gameObject.CompareTag(tagToCollide))
                    poolable.ReturnToPool();
            }
        }
    }
}