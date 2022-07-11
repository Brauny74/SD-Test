using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTools
{
    public class Pooler : MonoBehaviour
    {
        [SerializeField]
        protected int poolSize;
        [SerializeField]
        protected bool expandablePool;
        
        [Tooltip("Must contain Poolable component, or won't work.")]
        [SerializeField]
        protected GameObject objectToPool;

        protected List<Poolable> pool;

        protected virtual void Start()
        {
            FillObjectPool();
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].Active)
                {
                    pool[i].Activate(true);
                    return pool[i].gameObject;
                }
            }
            if (expandablePool)
            {
                return AddObject().gameObject;
            }
            return null;
        }

        public void ReturnPooledObject(Poolable pooledObject)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (pooledObject == pool[i])
                {
                    pooledObject.Activate(false);
                }
            }
        }

        protected virtual void FillObjectPool()
        {
            pool = new List<Poolable>();
            for (int i = 0; i < poolSize; i++)
            {
                AddObject().Activate(false);
            }
        }

        protected Poolable AddObject()
        {
            Poolable newObject = Instantiate(objectToPool, transform).GetComponent<Poolable>();
            if (newObject == null)
                Debug.LogError(newObject.name + " in pool " + gameObject.name + " is not Poolable.");
            newObject.Initialize(this);
            pool.Add(newObject);
            return newObject;
        }
    }
}