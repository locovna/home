using UnityEngine;

namespace Home
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _storageObject;
        [SerializeField] private MovementController _movementController;

        public void ResourceInteract(ResourceBehaviour resource, ETaskType currentTask, CharacterEntity characterEntity)
        {
            switch (currentTask)
            {
                case ETaskType.Use:
                    UseResource(resource, characterEntity);
                    break;

                case ETaskType.Store:
                    StoreResource(resource);
                    break;
            }
        }

        private void UseResource(ResourceBehaviour resource, CharacterEntity characterEntity)
        {
            resource.Apply(characterEntity);
        }

        private void StoreResource(ResourceBehaviour resource)
        {
            // grab the resource, move it to storage, drop
            Debug.Log("Store task is on CharacterBeh");
            //_movementController.MoveToPoint(_storageObject.transform.position);
        }
    }
}