using UnityEngine;
using UnityEngine.Events;

namespace TestTools
{ 
    public class EventOnTouch : MonoBehaviour
    {
        public string tagToTouch;

        public UnityEvent OnObjectTouch;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == tagToTouch)
                OnObjectTouch.Invoke();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == tagToTouch)
                OnObjectTouch.Invoke();
        }
    }
}