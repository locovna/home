using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Home
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class MovementController : MonoBehaviour
    {
        public LayerMask whatCanBeClickedOn;
        private NavMeshAgent agentCharacter;

        void Start()
        {
            agentCharacter = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            // MoveToClick();
        }

        private void MoveToClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 100, whatCanBeClickedOn))
                {
                    agentCharacter.SetDestination(hitInfo.point);
                }
            }
        }

        public void MoveToPoint(Vector3 point)
        {
            agentCharacter.SetDestination(point);
        }
    }
}