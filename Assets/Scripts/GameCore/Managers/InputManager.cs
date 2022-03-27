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

        void Update()
        {
            // if right click hits resource, move any free character to the resource
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

        private void Eat(ResourceBehaviour resourceToEat)
        {
            var movementController = GetFirstAvaibleCharacter();
            movementController.MoveToPoint(resourceToEat.transform.position);
            resourceToEat.Canceled += movementController.Idle;
        }

        private MovementController GetFirstAvaibleCharacter()
        {
            foreach (var character in CharacterManager.characterList)
            {
                var behaviour = character.prefab.GetComponent<CharacterBehaviour>();
                if (!behaviour.isOnTask)
                {
                    return character.prefab.GetComponent<MovementController>();
                }
            }
            return null;
        }
    }
}
