using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectHome.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Home
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CoreGameDataContainer _coreGameDataContainer;
        [SerializeField] private CharacterManager _characterManager;
        [SerializeField] private GameOverPopup _deathPopup;
        [SerializeField] private int _minAmountOfCharacters = 4;
        [SerializeField] private int _maxAmountOfCharacters = 15;
        [SerializeField] private int _resourcesAmount = 150;
        [SerializeField] private ResourceManager _resourceManager;
        [SerializeField] private ObjectDistributionManager _objectDistributionManager;

        private void Awake()
        {
            _resourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        }

        private void Start()
        {
            SpawnCharacters();
            GenerateResources(_resourcesAmount);
        }

        private void OnDestroy()
        {
            _resourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
        }

        private void GenerateResources(int resourceAmount)
        {
            var resources = _resourceManager.GenerateResources(resourceAmount, _coreGameDataContainer.ResourcePrefab)
                .ToArray();
            _resourceManager.RegisterResourceInstances(resources);
            DistributeEntities(resources.Select(x => x.transform));
        }

        private void OnResourceAmountChanged(int initialResourceAmount, int currentResourceAmount)
        {
            Debug.Log($"Current resource amount {currentResourceAmount}");

            if (!(currentResourceAmount <= _resourcesAmount * 0.25f))
                return;

            // TODO: Refactor / expose values in Random.Range method
            var resourceSpawnAmount = _resourcesAmount / Random.Range(2, 5);
            GenerateResources(resourceSpawnAmount);
        }

        private void SpawnCharacters()
        {
            var charactersAmount = Random.Range(_minAmountOfCharacters, _maxAmountOfCharacters);
            var prefabs =
                _characterManager.GenerateCharacterPrefabs(charactersAmount, _coreGameDataContainer.CharacterBehaviour)
                    .ToArray();

            foreach (var characterEntity in prefabs)
            {
                _characterManager.RegisterCharacterInstance(characterEntity);
            }

            DistributeEntities(prefabs.Select(x => x.transform));

            _characterManager.OnAllCharactersDead += GameOver;
        }

        private void DistributeEntities(IEnumerable<Transform> entities)
        {
            foreach (var prefab in entities.ToArray())
            {
                prefab.transform.position = _objectDistributionManager.GetRandomPosition();
            }
        }

        private void GameOver()
        {
            Debug.Log("All characters dead! Game Over!");
            // ResourceManager.resources.Clear();
            // if (deathPopup != null)
            // {
            //     deathPopup.SetActive(true);
            // }
        }

        // Scene Manager
        public void LoadStartScene()
        {
            // if (_deathPopup != null)
            // {
            //     _deathPopup.SetActive(false);
            // }

            SceneManager.LoadScene(0);
        }
    }
}