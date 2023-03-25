using System;
using UnityEngine;

namespace Home
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private CharacterManager _characterManager;

        private void Update()
        {
            switch (TaskManager.currentTask)
            {
                case ETaskType.Move:
                    PerformMoveTask();
                    break;

                case ETaskType.Eat:
                case ETaskType.Store:
                    PerformEatOrStore();
                    break;
            }
        }

        private void PerformEatOrStore()
        {
            Debug.Log("Listen to EAT or STORE task");
            // if click hits resource, move any character to the resource
            if (!Input.GetMouseButtonDown(0))
                return;

            if (!Physics.Raycast(GetCameraRay(), out var hit))
                return;

            if (!hit.collider.TryGetComponent<ResourceBehaviour>(out var resource))
                return;

            Debug.Log("resource is clicked");
            resource.ClickOnResource();

            if (resource.active)
            {
                if (TaskManager.currentTask == ETaskType.Eat)
                    Eat(resource);
                else
                    Store(resource);
            }
        }

        private void PerformMoveTask()
        {
            Debug.Log("Listen to MOVE task");
            // if click hits the ground, move any character to the point
            if (!Input.GetMouseButtonDown(0))
                return;

            if (Physics.Raycast(GetCameraRay(), out var hitInfo, 100, _groundLayerMask))
            {
                var movementController = _characterManager.GetAnyCharacterMovementController();
                movementController.MoveToPoint(hitInfo.point);
            }
        }

        private void Eat(ResourceBehaviour resourceToEat)
        {
            var movementController = _characterManager.GetAnyCharacterMovementController();
            movementController.MoveToPoint(resourceToEat.transform.position);
            resourceToEat.Canceled += movementController.Idle;
        }

        private void Store(ResourceBehaviour resourceToEat)
        {
            Debug.Log("Store is called");
            var movementController = _characterManager.GetAnyCharacterMovementController();
            movementController.MoveToPoint(resourceToEat.transform.position);
            resourceToEat.Canceled += movementController.Idle;
        }

        private Ray GetCameraRay()
        {
            return _gameCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}