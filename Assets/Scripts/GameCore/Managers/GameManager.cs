using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Home
{
    public class GameManager : MonoBehaviour
    {
        public static GameObject characterPrefab { get; private set; }
        private int numberOfCharacters = 3;
        private Scene scene;

        void Start()
        {
            LoadResources();
            Generate();
            Spawn();
        }

        private void LoadResources()
        {
            characterPrefab = Resources.Load<GameObject>("Prefabs/Character");
        }

        private void Generate()
        {
            CharacterManager.GenerateCharacters(numberOfCharacters);
            CharacterManager.AllDead += GameOver;
        }

        private void Spawn()
        {
            SpawnGameObject(CharacterManager.characterList[0].prefab);
            SpawnGameObject(CharacterManager.characterList[1].prefab);
            SpawnGameObject(CharacterManager.characterList[2].prefab);
        }

        private void SpawnGameObject(GameObject gameObject)
        {
            float xPosition;
            float yPosition = 0.5f;
            float zPosition;

            xPosition = Random.Range(-40, 40);
            zPosition = Random.Range(-40, 40);
            gameObject.transform.position = new Vector3(xPosition, yPosition, zPosition);
        }

        private void GameOver()
        {
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
