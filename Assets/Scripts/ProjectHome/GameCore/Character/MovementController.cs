using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Home
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _checkDistance = 0.1f;

        private Coroutine _coroutine;

        public float Speed
        {
            get => _agent.speed;
            set => _agent.speed = value;
        }

        public void MoveTo(Vector3 point, Action onPointReached)
        {
            _agent.destination = (point);

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(CheckPointReach(point, onPointReached));
        }

        private IEnumerator CheckPointReach(Vector3 point, Action onPointReached)
        {
            while (Vector3.Distance(transform.position, point) >= Mathf.Max(_agent.stoppingDistance, _checkDistance))
            {
                yield return null;
            }

            onPointReached?.Invoke();
        }

        public Vector3[] GetPath()
        {
            return _agent.path.corners;
        }
    }
}