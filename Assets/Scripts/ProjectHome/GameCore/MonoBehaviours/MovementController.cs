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
        private CharacterBehaviour characterBehaviour;

        void Start()
        {
            agentCharacter = GetComponent<NavMeshAgent>();
            characterBehaviour = GetComponent<CharacterBehaviour>();
        }

        void LateUpdate()
        {
            if (!characterBehaviour.isOnTask)
            {
                PlayIdleAnimation();
            }
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
            characterBehaviour.isOnTask = true;
            agentCharacter.isStopped = false;
            agentCharacter.SetDestination(point);
        }

        public void Idle()
        {
            characterBehaviour.isOnTask = false;
            agentCharacter.isStopped = true;
            PlayIdleAnimation();
        }

        private void PlayIdleAnimation()
        {
            float x = transform.position.x;
            float z = transform.position.z;
            transform.position = new Vector3(x, (Mathf.Sin(Time.time) + 12) / 7, z);
        }
    }
}