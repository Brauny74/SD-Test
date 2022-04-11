using UnityEngine;
using UnityEngine.AI;

namespace TestGame
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        public Animator animatedBody;
        NavMeshAgent _agent;

        protected virtual void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Stop()
        {
            _agent.isStopped = true;
        }

        protected void MoveTo(Vector3 target)
        {
            NavMeshPath path = new NavMeshPath();
            _agent.CalculatePath(target, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                _agent.isStopped = false;
                _agent.SetPath(path);
            }
        }
        
        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            animatedBody.SetFloat("Velocity", _agent.velocity.magnitude);
        }
    }
}