using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHome;
using ProjectHome.Data;
using UnityEngine;

namespace Home
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private CharacterGenerationDataContainer _characterGenerationData;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private SelectionManager _selectionManager;

        private int _lastCharacterId;

        private readonly List<CharacterEntity> _characterInstances;
        private readonly List<CharacterEntity> _deadCharacters;

        public event Action OnAllCharactersDead;

        private CharacterManager()
        {
            _characterInstances = new List<CharacterEntity>();
            _deadCharacters = new List<CharacterEntity>();
        }

        private void OnEnable()
        {
            _inputManager.OnPointerClickCollider += OnPointerColliderHandler;
        }

        private void OnDisable()
        {
            _inputManager.OnPointerClickCollider -= OnPointerColliderHandler;
        }

        private bool TryGetNextCharacter(out CharacterEntity character)
        {
            character = null;
            var queue = new Queue<CharacterEntity>(
                _selectionManager.SelectedCharacters.Where(x => x.gameObject.activeSelf));

            if (queue.Count == 0)
                return false;

            character = queue.Dequeue();
            return true;
        }

        private void OnPointerColliderHandler(Collider other)
        {
            if (!TryGetNextCharacter(out var character))
                return;

            character.MoveTo(other);
            _selectionManager.MarkUnselected(character);
        }

        private void Update()
        {
            var dt = Time.deltaTime;

            foreach (var characterEntity in _characterInstances.Where(x => _deadCharacters.IndexOf(x) < 0))
            {
                characterEntity.Tick(dt);
            }
        }

        public IEnumerable<CharacterEntity> GenerateCharacterPrefabs(int quantity, CharacterEntity characterPrefab)
        {
            var prefabInstances = new CharacterEntity[quantity];

            for (int i = 0; i < quantity; i++)
            {
                var characterPrefabInstance = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
                InitCharacterInstance(characterPrefabInstance, _lastCharacterId);
                prefabInstances[i] = characterPrefabInstance;
                _lastCharacterId++;
            }

            return prefabInstances;
        }

        public void RegisterCharacterInstance(CharacterEntity characterEntity)
        {
            var index = _characterInstances.IndexOf(characterEntity);

            if (index >= 0)
            {
                Debug.Log($"The character {characterEntity.Id} is already registered!");
                return;
            }

            _characterInstances.Add(characterEntity);
        }

        private void InitCharacterInstance(CharacterEntity character, int id)
        {
            var healthLimit = _characterGenerationData.HealthLimits.GetRandom();
            var selfDamage = _characterGenerationData.SelfDamageLimits.GetRandom();
            var speed = _characterGenerationData.SpeedLimits.GetRandom();
            var damageMultiplier = _characterGenerationData.DamageLimits.GetRandom();
            var characterName = _characterGenerationData.GetRandomName();
            character.Init(id, healthLimit, selfDamage, speed, damageMultiplier,
                characterName);
            character.OnDeath += OnCharacterDeathHandler;
        }

        private void OnCharacterDeathHandler(CharacterEntity character)
        {
            _deadCharacters.Add(character);

            if (_deadCharacters.Count == _characterInstances.Count)
            {
                OnAllCharactersDead?.Invoke();
            }
        }

        public IEnumerable<CharacterEntity> GetAliveCharacters()
        {
            return _characterInstances.Where(x => _deadCharacters.IndexOf(x) < 0);
        }
    }
}