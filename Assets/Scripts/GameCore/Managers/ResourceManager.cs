using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public static class ResourceManager
    {
        public static List<Resource> resources = new List<Resource>();

        public static void GenerateResources()
        {
            Resource resource = ResourceCreator.GenerateResource();
            resource.prefab = Helper.InstantiateObject(GameManager.resourcePrefab);
            PassResourceData(resource);
            resources.Add(resource);
        }

        private static void PassResourceData(Resource resource)
        {
            ResourceBehaviour resourceBehaviour= resource.prefab.GetComponent<ResourceBehaviour>();
            if (resourceBehaviour != null)
            {
                resourceBehaviour.InitializeResource(resource);
            }
        }
    }
}
