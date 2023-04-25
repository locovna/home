using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Home
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private BaseResource[] _resources;
        [SerializeField] private ObjectDistributionManager _objectDistributionManager;

        public void GenerateResources(int quantity, ResourceBehaviour resourcePrefab)
        {
            for (int i = 0; i < quantity; i++)
            {
                var resourceInstance = Instantiate(resourcePrefab, _objectDistributionManager.GetRandomPosition(),
                    Quaternion.identity);
                resourceInstance.Init(_resources.First());
            }
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