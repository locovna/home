using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Home
{
    public class CharacterBehaviour : MonoBehaviour
    {
        private Character character;
        public bool isOnTask = false;
        public GameObject storageObject;
        private TextMeshProUGUI text;
        private Image healthBar;
        private MovementController movementController;

        void Start()
        {
            movementController = GetComponent<MovementController>();
        }

        void Update()
        {
            UpdateHealthBar();
            character.TakeDamage(character.selfDamage);
        }

        // "Eat" and "Store" task - to refactor
        void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.collider.tag == "Resource")
            {
                Debug.Log(character.name + " hits " + collisionInfo.collider.name);

                ResourceBehaviour resourceBehaviour = collisionInfo.collider.gameObject.GetComponent<ResourceBehaviour>();
                if (resourceBehaviour != null)
                {
                    if (TaskManager.currentTask == ETaskType.Eat)
                    {
                        resourceBehaviour.ApplyEffects(character);
                        Destroy(collisionInfo.collider.gameObject);
                        ResourceManager.resources.Remove(resourceBehaviour.resource); // move to resource manager or resource itself
                        isOnTask = false;
                    }
                    else if (TaskManager.currentTask == ETaskType.Store)
                    {
                        // grab the resource, move it to storage, drop
                        Debug.Log("Store task is on CharacterBeh");
                        movementController.MoveToPoint(storageObject.transform.position);
                    }
                }
            }
            else
            {
                Debug.Log(character.name + " hits " + collisionInfo.collider.name);
            }
        }

        public void InitializeCharacter(Character characterToInitialize)
        {
            characterToInitialize.Death += Death;
            character = characterToInitialize;
            SetUI();
            Debug.Log($"{gameObject.GetInstanceID()} {character.name} is set. {character.healthLimit} {character.selfDamage}");
        }

        // to fix: no need in id parameter
        private void Death(string id)
        {
            Debug.Log($"{gameObject.GetInstanceID()} {character.name} is dead!");
            character.Death -= Death;
            Destroy(gameObject);
        }

        // move to View Controller
        private void SetUI()
        {
            healthBar = gameObject.GetComponentInChildren<Image>();
            text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            text.text = character.name;
        }

        private void UpdateHealthBar()
        {
            healthBar.fillAmount = character.health / character.healthLimit;
        }
    }
}
