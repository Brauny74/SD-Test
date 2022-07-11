using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTools
{
    public class Poolable : MonoBehaviour
    {
        public bool Active;

        protected Pooler creatorPool;

        public void Initialize(Pooler cPooler)
        {
            gameObject.SetActive(true);
            creatorPool = cPooler;
        }

        public void Activate(bool newState)
        {
            gameObject.SetActive(newState);
        }

        public void ReturnToPool()
        {
            creatorPool.ReturnPooledObject(this);
        }
    }
}
