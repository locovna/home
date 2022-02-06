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
        private int numberOfCharacters = 10;
        private int numberOfResources = 500;

        void Start()
        {
            LoadResources();
            Generate();
            Spawn();
        }

        private void LoadResources()
        {
            characterPrefab = Resources.Load<GameObject>("Prefabs/Character");
            resourcePrefab = Resources.Load<GameObject>("Prefabs/Resource");
        }

        private void Generate()
        {
            CharacterManager.GenerateCharacters(numberOfCharacters);
            CharacterManager.AllDead += GameOver;
            ResourceManager.GenerateResources(numberOfResources);
        }

        private void Spawn()
        {
            for(int i = 0; i < CharacterManager.characterList.Count; i++)
            {
                SpawnGameObject(CharacterManager.characterList[i].prefab);
            }

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

            xPosition = Random.Range(-120, 80);
            zPosition = Random.Range(-110, 60);
            gameObject.transform.position = new Vector3(xPosition, yPosition, zPosition);
        }

        private void GameOver()
        {
            ResourceManager.resources.Clear();
            if (deathPopup != null)
            {    
                deathPopup.SetActive(true);
            }
        }

        public void LoadStartScene()
        {
            if (deathPopup != null)
            {    
                deathPopup.SetActive(false);
            }
            SceneManager.LoadScene(0);
        }
    }
}
