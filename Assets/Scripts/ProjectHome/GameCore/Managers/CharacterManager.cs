using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public static class CharacterManager
    {
        public static List<Character> characterList = new List<Character>();

        public delegate void CharacterManagerDelegate();

        public static event CharacterManagerDelegate AllDead;

        public static void GenerateCharacters(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Character character = CharacterCreator.CreateRandomizedCharacter();
                character.prefab = Helper.InstantiateObject(GameManager.characterPrefab);
                PassCharacterData(character);
                character.Death += UpdateCharacterList;
                characterList.Add(character);
            }
        }

        private static void PassCharacterData(Character character)
        {
            CharacterBehaviour behaviour = character.prefab.GetComponent<CharacterBehaviour>();
            if (behaviour != null)
            {
                behaviour.InitializeCharacter(character);
            }
        }

        private static void UpdateCharacterList(string deadCharacterID)
        {
            Character deadCharacter = characterList.Find(character => character.id == deadCharacterID);
            if (deadCharacter != null)
            {
                deadCharacter.Death -= UpdateCharacterList;
                characterList.Remove(deadCharacter);
            }

            if (characterList.Count == 0)
            {
                Debug.Log("All Dead!");
                AllDead?.Invoke();
            }
        }

        public static MovementController GetAnyCharacterMovementController()
        {
            var index = Random.Range(0, characterList.Count);
            var character = characterList[index];
            return character.prefab.GetComponent<MovementController>();
        }
    }
}