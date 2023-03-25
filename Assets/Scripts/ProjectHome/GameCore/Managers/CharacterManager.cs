using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Home
{
    public class CharacterManager : MonoBehaviour
    {
        private readonly List<Character> characterList = new List<Character>();

        public int AliveCharactersCount => characterList.Count;
        public event Action OnAllCharactersDead;

        public CharacterBehaviour[] GenerateCharacterPrefabs(int quantity, CharacterBehaviour characterPrefab)
        {
            var prefabInstances = new CharacterBehaviour[quantity];

            for (int i = 0; i < quantity; i++)
            {
                Character character = CharacterCreator.CreateRandomizedCharacter();
                var characterPrefabInstance = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
                characterPrefabInstance.InitializeCharacter(character);
                character.prefab = characterPrefabInstance.gameObject;
                character.Death += UpdateCharacterList;
                characterList.Add(character);
                prefabInstances[i] = characterPrefabInstance;
            }

            return prefabInstances;
        }

        private void UpdateCharacterList(string deadCharacterID)
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
                OnAllCharactersDead?.Invoke();
            }
        }

        public MovementController GetAnyCharacterMovementController()
        {
            var index = Random.Range(0, characterList.Count);
            var character = characterList[index];
            return character.prefab.GetComponent<MovementController>();
        }
    }
}