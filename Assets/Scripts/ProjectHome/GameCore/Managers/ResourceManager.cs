using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Home
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private float _spawnRange = 10f;
        [SerializeField] private BaseResource[] _resources;

        public void GenerateResources(int quantity, ResourceBehaviour resourcePrefab)
        {
            for (int i = 0; i < quantity; i++)
            {
                var resourceInstance = Instantiate(resourcePrefab, GetRandomPosition(), Quaternion.identity);
                resourceInstance.Init(_resources.First());
            }
        }

        private Vector3 GetRandomPosition()
        {
            var randomPosInsideCircle = Random.insideUnitCircle * _spawnRange;
            return new Vector3(randomPosInsideCircle.x, transform.position.y, randomPosInsideCircle.y);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _spawnRange);
        }

        // private static void PassResourceData(Resource resource)
        // {
        //     ResourceBehaviour resourceBehaviour = resource.prefab.GetComponent<ResourceBehaviour>();
        //     if (resourceBehaviour != null)
        //     {
        //         resourceBehaviour.InitializeResource(resource);
        //     }
        // }
    }
}