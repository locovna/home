using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Home
{
    public class CharacterBehaviour : MonoBehaviour
    {
        public TextMeshProUGUI text;
        private Character character;

        public void InitializeCharacter(Character characterToInitialize)
        {
            character = characterToInitialize;
            SetName();
        }

        private void SetName()
        {
            text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            text.text = character.name;
            print(gameObject.GetInstanceID() + ": data in character behaviour: " + character.name);
        }
    }
}
