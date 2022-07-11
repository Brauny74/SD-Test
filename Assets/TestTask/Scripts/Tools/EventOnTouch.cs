using UnityEngine;
using UnityEngine.Events;

namespace TestTools
{ 
    public class EventOnTouch : MonoBehaviour
    {
        [SerializeField]
        protected string tagToTouch;

        [SerializeField]
        protected UnityEvent OnObjectTouch;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(tagToTouch))
                OnObjectTouch.Invoke();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(tagToTouch))
                OnObjectTouch.Invoke();
        }
    }
}