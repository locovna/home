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
        private TextMeshProUGUI text;
        private Image healthBar;

        void Update()
        {
            UpdateHealthBar();
            character.TakeDamage(character.selfDamage);
        }

        void OnCollisionEnter(Collision collisionInfo) 
        {
            if (collisionInfo.collider.tag == "Resource") 
            {
                Debug.Log(character.name + " hits " + collisionInfo.collider.name);

                ResourceBehaviour resourceBehaviour = collisionInfo.collider.gameObject.GetComponent<ResourceBehaviour>();
                if (resourceBehaviour != null)
                {
                    resourceBehaviour.ApplyEffects(character);
                    Destroy(collisionInfo.collider.gameObject);
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
