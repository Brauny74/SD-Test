using System;
using UnityEngine;
using TestTools;

namespace TestGame
{
    [RequireComponent(typeof(TestTools.Pooler))]
    public class PlayerShoot : MonoBehaviour
    {
        public float reloadTime;
        private float _currentReloadTime;
        private bool isReloading;

        public Transform shootingPoint;

        Pooler pooler;

        private void Awake()
        {
            pooler = GetComponent<Pooler>();
        }

        private void Update()
        {
            if (isReloading)
            {
                _currentReloadTime -= Time.deltaTime;
                if (_currentReloadTime <= 0)
                {
                    isReloading = false;
                    _currentReloadTime = reloadTime;
                } 
            }
        }

        public void Shoot(Vector3 direction)
        {
            try
            {
                GameObject bullet = pooler.GetPooledObject();
                bullet.transform.position = shootingPoint.position;
                bullet.transform.LookAt(direction);
                isReloading = true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}