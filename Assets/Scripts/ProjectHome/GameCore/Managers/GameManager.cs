using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Home
{
    public class GameManager : MonoBehaviour
    {
        public GameObject deathPopup;

        public static GameObject characterPrefab { get; private set; }
        public static GameObject resourcePrefab { get; private set; }
        private int maxNumberOfCharacters = 15;
        private int numberOfResources = 150;

        void Start()
        {
            LoadResources();
            Generate();
            SpawnCharacters();
            SpawnResources();
        }

        void Update()
        {
            ControlNumberOfResources();
        }

        private void LoadResources()
        {
            characterPrefab = Resources.Load<GameObject>("Prefabs/Character");
            resourcePrefab = Resources.Load<GameObject>("Prefabs/Resource");
        }

        private void Generate()
        {
            CharacterManager.GenerateCharacters(Random.Range(4, maxNumberOfCharacters));
            CharacterManager.AllDead += GameOver;
            ResourceManager.GenerateResources(numberOfResources);
        }

        private void GameOver()
        {
            ResourceManager.resources.Clear();
            if (deathPopup != null)
            {    
                deathPopup.SetActive(true);
            }
        }

        // Scene Manager
        public void LoadStartScene()
        {
            if (deathPopup != null)
            {    
                deathPopup.SetActive(false);
            }
            SceneManager.LoadScene(0);
        }

        // Spawn Manager
        private void SpawnCharacters()
        {
            for(int i = 0; i < CharacterManager.characterList.Count; i++)
            {
                SpawnGameObject(CharacterManager.characterList[i].prefab);
            }
        }

        private void SpawnResources()
        {
            for(int i = 0; i < ResourceManager.resources.Count; i++)
            {
                SpawnGameObject(ResourceManager.resources[i].prefab);
            }
        }

        private void SpawnGameObject(GameObject gameObject)
        {
            float xPosition;
            float yPosition = 5f;
            float zPosition;

            xPosition = Random.Range(-30, 30);
            zPosition = Random.Range(-30, 30);
            if(gameObject != null)
            {
                gameObject.transform.position = new Vector3(xPosition, yPosition, zPosition);
            }
        }

        private void ControlNumberOfResources()
        {
            if(ResourceManager.resources.Count <= numberOfResources/4)
            {
                ResourceManager.GenerateResources(numberOfResources/Random.Range(2, 5));
                SpawnResources();
            }
        }
    }
}
