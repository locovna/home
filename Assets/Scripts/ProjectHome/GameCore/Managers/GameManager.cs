using System.Collections;
using System.Collections.Generic;
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

        private void Start()
        {
            Generate();
            SpawnResources();
        }

        private void Update()
        {
            ControlNumberOfResources();
        }

        private void Generate()
        {
            SpawnCharacters();
            GenerateResources();
        }

        private void GenerateResources()
        {
            _resourceManager.GenerateResources(_resourcesAmount, _coreGameDataContainer.ResourcePrefab);
        }

        private void SpawnCharacters()
        {
            var charactersAmount = Random.Range(_minAmountOfCharacters, _maxAmountOfCharacters);
            var prefabs =
                _characterManager.GenerateCharacterPrefabs(charactersAmount, _coreGameDataContainer.CharacterBehaviour);

            foreach (var prefab in prefabs)
            {
                PlaceGameObjectRandomly(prefab.gameObject);
            }

            _characterManager.OnAllCharactersDead += GameOver;
        }

        private void GameOver()
        {
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

        private void SpawnResources()
        {
            // for (int i = 0; i < ResourceManager.resources.Count; i++)
            // {
            //     PlaceGameObjectRandomly(ResourceManager.resources[i].prefab);
            // }
        }

        private void PlaceGameObjectRandomly(GameObject go)
        {
            float xPosition;
            float yPosition = 5f;
            float zPosition;

            xPosition = Random.Range(-30, 30);
            zPosition = Random.Range(-30, 30);
            if (go != null)
            {
                go.transform.position = new Vector3(xPosition, yPosition, zPosition);
            }
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