using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectHome.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            SpawnCharacters();
            GenerateResources();
        }

        private void GenerateResources()
        {
            var resources = _resourceManager.GenerateResources(_resourcesAmount, _coreGameDataContainer.ResourcePrefab);
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

            foreach (var prefab in prefabs)
            {
                prefab.transform.position = _objectDistributionManager.GetRandomPosition();
            }

            _characterManager.OnAllCharactersDead += GameOver;
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

        private void ControlNumberOfResources()
        {
            // if (ResourceManager.resources.Count <= numberOfResources / 4)
            // {
            //     ResourceManager.GenerateResources(numberOfResources / Random.Range(2, 5),
            //         _coreGameDataContainer.ResourcePrefab);
            //     SpawnResources();
            // }
        }
    }
}