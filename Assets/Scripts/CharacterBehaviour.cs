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

        public void InitializeCharacter(Character characterToInitialize)
        {
            characterToInitialize.Death += Death;
            character = characterToInitialize;
            SetUI();
            Debug.Log($"{gameObject.GetInstanceID()} {character.name} is set. {character.healthLimit} {character.selfDamage}");
        }

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

        // to fix: no need in id parameter
        private void Death(string id)
        {
            Debug.Log($"{gameObject.GetInstanceID()} {character.name} is dead!");
            character.Death -= Death;
            Destroy(gameObject);
        }
    }
}
