using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class Route : MonoBehaviour
    {
        private Transform[] waypoints;
        private int currentWaypoint;

        // Start is called before the first frame update
        void Start()
        {
            currentWaypoint = 0;
            waypoints = transform.GetComponentsInChildren<Transform>();
        }

        public Vector3 NextWaypointPos()
        {
            currentWaypoint++;
            if (currentWaypoint < waypoints.Length)
            {
                return waypoints[currentWaypoint].position;
            }
            return waypoints[waypoints.Length].position;
        }

        public Vector3 GetWaypointPos()
        {
            return waypoints[currentWaypoint].position;
        }
    }
}