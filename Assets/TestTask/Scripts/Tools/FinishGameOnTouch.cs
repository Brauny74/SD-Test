using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class FinishGameOnTouch : MonoBehaviour
    {
        [SerializeField]
        protected string PlayerTag;

        [SerializeField]
        protected RectTransform finishGameTap;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
                finishGameTap.gameObject.SetActive(true);
        }
    }
}