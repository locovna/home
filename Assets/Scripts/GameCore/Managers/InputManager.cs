using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Home
{
    public class InputManager : MonoBehaviour
    {
        public Camera GameCamera;
        private Resource currentResource = null;
        public LayerMask whatCanBeClickedOn;

        private string currentTask = null;

        void Update()
        {
            if (currentTask == "MOVE")
            {
                Debug.Log("Listen to MOVE task");
                // if click hits the ground, move any character to the point
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo, 100, whatCanBeClickedOn))
                    {
                        var movementController = GetAnyCharacter().prefab.GetComponent<MovementController>();
                        movementController.MoveToPoint(hitInfo.point);
                    }
                }
            }
            else if (currentTask == "EAT")
            {
                Debug.Log("Listen to EAT task");
                // if click hits resource, move any character to the resource
                if (Input.GetMouseButtonDown(0))
                {
                    var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("resource is clicked");
                        var clickedResource = hit.collider.GetComponentInParent<ResourceBehaviour>();
                        currentResource = clickedResource.resource;
                        clickedResource.ClickOnResource();

                        if (clickedResource.active)
                        {
                            Eat(clickedResource);
                        }
                    }
                }
            }
            else if (currentTask == "STORE")
            {
                Debug.Log("Listen to STORE task");
            }
            else
            {
                currentTask = null;
            }
        }

        private void Eat(ResourceBehaviour resourceToEat)
        {
            var movementController = GetAnyCharacter().prefab.GetComponent<MovementController>();
            movementController.MoveToPoint(resourceToEat.transform.position);
            resourceToEat.Canceled += movementController.Idle;
        }

        private Character GetAnyCharacter()
        {
            return CharacterManager.characterList[Random.Range(0, CharacterManager.characterList.Count)];
        }

        public void TaskMoveToClick()
        {
            currentTask = "MOVE";
        }

        public void TaskEat()
        {
            currentTask = "EAT";
        }

        public void TaskStore()
        {
            currentTask = "STORE";
        }

        public void TaskSelectAll()
        {
            Debug.Log("Select All");
        }

        public void TaskSelectIdle()
        {
            Debug.Log("Select Idle");
        }
    }
}
