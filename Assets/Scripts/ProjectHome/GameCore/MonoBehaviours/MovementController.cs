using UnityEngine;
using UnityEngine.AI;

namespace Home
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        public void MoveTo(Vector3 point)
        {
            _agent.SetDestination(point);
        }
    }
}