using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class PlayerMovement : Movement
    {
        [SerializeField]
        protected Route route;

        public void Move()
        {
            MoveTo(route.NextWaypointPos());
        }
    }
}