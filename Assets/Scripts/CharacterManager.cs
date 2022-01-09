using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class CharacterManager : MonoBehaviour
    {
        public static List<Character> characterList = new List<Character>();

        public static void GenerateCharacters(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Character character = CharacterCreator.CreateRandomizedCharacter();
                character.prefab = Instantiate(GameManager.characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                characterList.Add(character);
            }
        }

        public static void PassCharacterData(Character character)
        {
            CharacterBehaviour behaviour = character.prefab.GetComponent<CharacterBehaviour>();
            if (behaviour != null)
            {
                behaviour.InitializeCharacter(character);
            }
        }
    }
}
