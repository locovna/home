using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class GameManager : MonoBehaviour
    {
        private int numberOfCharacters = 3;
        public static GameObject characterPrefab;

        void Start()
        {
            LoadResources();
            Generate();
            Spawn();
            CharacterManager.PassCharacterData(CharacterManager.characterList[0]);
            CharacterManager.PassCharacterData(CharacterManager.characterList[1]);
            CharacterManager.PassCharacterData(CharacterManager.characterList[2]);
        }

        private void LoadResources()
        {
            characterPrefab = Resources.Load<GameObject>("Prefabs/Character");
        }

        private void Generate()
        {
            CharacterManager.GenerateCharacters(numberOfCharacters);
        }

        private void Spawn()
        {
            SpawnGameObject(CharacterManager.characterList[0].prefab);
            SpawnGameObject(CharacterManager.characterList[1].prefab);
            SpawnGameObject(CharacterManager.characterList[2].prefab);
        }

        public void SpawnGameObject(GameObject gameObject)
        {
            float xPosition;
            float yPosition = 0.5f;
            float zPosition;

            xPosition = Random.Range(-40, 40);
            zPosition = Random.Range(-40, 40);
            gameObject.transform.position = new Vector3(xPosition, yPosition, zPosition);
        }
    }
}
