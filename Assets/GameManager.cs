using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class GameManager : MonoBehaviour
    {
        public int numberOfCharacters = 10;
        public List<Character> characterList = new List<Character>();

        void Start()
        {
            CreateCharacters(numberOfCharacters);
            print(characterList.Count);
        }

        public void CreateCharacters(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Character character = CharacterCreator.CreateCharacter();
                characterList.Add(character);
            }
        }
    }
}
