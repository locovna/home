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
        private readonly List<int> _deadCharacters;

        public event Action OnAllCharactersDead;

        private CharacterManager()
        {
            _characterInstances = new List<CharacterEntity>();
            _deadCharacters = new List<int>();
        }

        private void OnEnable()
        {
            _inputManager.OnPointerClick += OnPointerHandler;
        }

        private void OnDisable()
        {
            _inputManager.OnPointerClick -= OnPointerHandler;
        }

        private void OnPointerHandler(Vector3 point)
        {
            var queue = new Queue<CharacterEntity>(_selectionManager.SelectedCharacters);

            if (queue.Count == 0)
                return;

            var character = queue.Dequeue();
            character.MoveTo(point);
            _selectionManager.MarkUnselected(character);
        }

        private void Update()
        {
            var dt = Time.deltaTime;

            foreach (var characterEntity in _characterInstances)
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

            _characterInstances.AddRange(prefabInstances);

            return prefabInstances;
        }

        private void InitCharacterInstance(CharacterEntity character, int id)
        {
            var healthLimit = _characterGenerationData.HealthLimits.GetRandom();
            var selfDamage = _characterGenerationData.SelfDamageLimits.GetRandom();
            var speed = _characterGenerationData.SpeedLimits.GetRandom();
            var damageMultiplier = _characterGenerationData.DamageLimits.GetRandom();
            var speedMultiplier = _characterGenerationData.SpeedMultiplierLimits.GetRandom();
            var characterName = _characterGenerationData.GetRandomName();
            character.Init(id, healthLimit, selfDamage, speed, speedMultiplier, damageMultiplier,
                characterName);
            character.OnDeath += OnCharacterDeathHandler;
        }

        private void OnCharacterDeathHandler(int characterId)
        {
            _deadCharacters.Add(characterId);

            if (_deadCharacters.Count == _characterInstances.Count)
            {
                OnAllCharactersDead?.Invoke();
            }
        }

        public IEnumerable<CharacterEntity> GetAliveCharacters()
        {
            return _characterInstances.Where(x => !_deadCharacters.Contains(x.Id));
        }
    }
}