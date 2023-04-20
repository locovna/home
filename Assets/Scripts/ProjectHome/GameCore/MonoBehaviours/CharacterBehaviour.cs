using UnityEngine;

namespace Home
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _storageObject;
        [SerializeField] private MovementController _movementController;
        
        public void ResourceInteract(ResourceBehaviour resource, ETaskType currentTask)
        {
            switch (currentTask)
            {
                case ETaskType.Eat:
                    EatResource(resource);
                    break;

                case ETaskType.Store:
                    StoreResource(resource);
                    break;
            }
        }

        private void EatResource(ResourceBehaviour resource)
        {
            //  resource.ApplyEffects(character);
            // // Destroy(collisionInfo.collider.gameObject);
            // // move to resource manager or resource itself
            //  ResourceManager.resources.Remove(resourceBehaviour.resource);
        }
        
        private void StoreResource(ResourceBehaviour resource)
        {
            // grab the resource, move it to storage, drop
            Debug.Log("Store task is on CharacterBeh");
            //_movementController.MoveToPoint(_storageObject.transform.position);
        }
    }
}