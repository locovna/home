using System;
using System.Collections.Generic;
using System.Linq;
using Home;
using UnityEngine;

namespace ProjectHome
{
    public class SelectionManager : MonoBehaviour
    {
        private CharacterEntity[] _selectedCharacters;

        private SelectionManager()
        {
            _selectedCharacters = Array.Empty<CharacterEntity>();
        }

        public void SetCharactersSelected(IEnumerable<CharacterEntity> characterEntities)
        {
            foreach (var character in _selectedCharacters)
            {
                character.SetSelected(false);
            }

            _selectedCharacters = characterEntities.ToArray();

            foreach (var character in _selectedCharacters)
            {
                character.SetSelected(true);
            }
        }
    }
}