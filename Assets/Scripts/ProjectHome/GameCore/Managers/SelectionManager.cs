using System;
using System.Collections.Generic;
using System.Linq;
using Home;
using UnityEngine;

namespace ProjectHome
{
    public class SelectionManager : MonoBehaviour
    {
        private List<CharacterEntity> _selectedCharacters;

        public IEnumerable<CharacterEntity> SelectedCharacters => _selectedCharacters;

        private SelectionManager()
        {
            _selectedCharacters = new List<CharacterEntity>();
        }

        public void SetCharactersSelected(IEnumerable<CharacterEntity> characterEntities)
        {
            foreach (var character in _selectedCharacters)
            {
                character.SetSelected(false);
            }

            _selectedCharacters = new List<CharacterEntity>(characterEntities);

            foreach (var character in _selectedCharacters)
            {
                character.SetSelected(true);
            }
        }

        public void MarkUnselected(CharacterEntity characterEntity)
        {
            var index = _selectedCharacters.IndexOf(characterEntity);

            if (index < 0)
                return;

            characterEntity.SetSelected(false);
            _selectedCharacters.RemoveAt(index);
        }
    }
}