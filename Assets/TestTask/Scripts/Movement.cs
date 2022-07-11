using UnityEngine;
using UnityEngine.AI;

namespace TestGame
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        protected Animator animatedBody;

        protected NavMeshAgent agent;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void Stop()
        {
            agent.isStopped = true;
        }

        protected void MoveTo(Vector3 target)
        {
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(target, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                agent.isStopped = false;
                agent.SetPath(path);
            }
        }
        
        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            animatedBody.SetFloat("Velocity", agent.velocity.magnitude);
        }
    }
}