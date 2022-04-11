using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTools
{
    public class Pooler : MonoBehaviour
    {
        public int poolSize;
        public bool expandablePool;
        public GameObject objectToPool;

        protected List<GameObject> pool;

        protected virtual void Start()
        {
            FillObjectPool();
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }
            if (expandablePool)
            {
                return AddObject();
            }
            return null;
        }

        protected virtual void FillObjectPool()
        {
            pool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                AddObject().SetActive(false);
            }
        }

        protected GameObject AddObject()
        {
            GameObject newObject = Instantiate(objectToPool, transform);
            pool.Add(newObject);
            return newObject;
        }
    }
}