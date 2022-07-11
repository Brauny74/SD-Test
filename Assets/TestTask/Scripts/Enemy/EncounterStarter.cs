using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class EncounterStarter : MonoBehaviour
    {
        [SerializeField]
        protected string PlayerTag;

        [SerializeField]
        protected EncounterManager encounterManager;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(PlayerTag))
                encounterManager.StartEncounter();
        }
    }
}