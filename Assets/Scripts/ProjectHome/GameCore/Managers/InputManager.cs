using UnityEngine;

namespace Home
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private LayerMask _groundLayerMask;

        private void Update()
        {
            switch (TaskManager.currentTask)
            {
                case "MOVE":
                    PerformMoveTask();
                    break;

                case "EAT":
                case "STORE":
                    PerformEatOrStore();
                    break;

                default:
                    TaskManager.currentTask = null;
                    break;
            }
        }

        private void PerformEatOrStore()
        {
            Debug.Log("Listen to EAT or STORE task");
            // if click hits resource, move any character to the resource
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _gameCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (!hit.collider.TryGetComponent<ResourceBehaviour>(out var resource))
                        return;

                    Debug.Log("resource is clicked");
                    resource.ClickOnResource();

                    if (resource.active)
                    {
                        if (TaskManager.currentTask == "EAT")
                            Eat(resource);
                        else
                            Store(resource);
                    }
                }
            }
        }

        private void PerformMoveTask()
        {
            Debug.Log("Listen to MOVE task");
            // if click hits the ground, move any character to the point
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 100, _groundLayerMask))
                {
                    var movementController = GetAnyCharacter().prefab.GetComponent<MovementController>();
                    movementController.MoveToPoint(hitInfo.point);
                }
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