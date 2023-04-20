using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHome.Data;
using UnityEngine;

namespace Home
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private CharacterGenerationDataContainer _characterGenerationData;
        [SerializeField] private InputManager _inputManager;

        private readonly List<CharacterEntity> _characterInstances;
        private readonly List<int> _deadCharacters;

        public event Action OnAllCharactersDead;

        private CharacterManager()
        {
            _characterInstances = new List<CharacterEntity>();
            _deadCharacters = new List<int>();
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
                InitCharacterInstance(characterPrefabInstance, i);
                prefabInstances[i] = characterPrefabInstance;
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
            character.Init(id, healthLimit, selfDamage, speed, speedMultiplier, damageMultiplier, _inputManager);
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