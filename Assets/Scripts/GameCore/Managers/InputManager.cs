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

        void Update()
        {
            if (TaskManager.currentTask == "MOVE")
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
            else if (TaskManager.currentTask == "EAT" || TaskManager.currentTask == "STORE")
            {
                Debug.Log("Listen to EAT or STORE task");
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
                            if(TaskManager.currentTask == "EAT")
                            Eat(clickedResource);
                            else
                            Store(clickedResource);
                        }
                    }
                }
            }
            else
            {
                TaskManager.currentTask = null;
            }
        }

        private void Eat(ResourceBehaviour resourceToEat)
        {
            var movementController = GetAnyCharacter().prefab.GetComponent<MovementController>();
            movementController.MoveToPoint(resourceToEat.transform.position);
            resourceToEat.Canceled += movementController.Idle;
        }

        private void Store(ResourceBehaviour resourceToEat)
        {
            Debug.Log("Store is called");
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
            TaskManager.currentTask = "MOVE";
        }

        public void TaskEat()
        {
            TaskManager.currentTask = "EAT";
        }

        public void TaskStore()
        {
            TaskManager.currentTask = "STORE";
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

    public static class TaskManager
    {
        // static string[] Tasks = {"MOVE", "EAT", "STORE"};
        static public string currentTask;
    }
}
