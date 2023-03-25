using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public static class ResourceManager
    {
        public static List<Resource> resources = new List<Resource>();

        public static void GenerateResources(int quantity, ResourceBehaviour resourcePrefab)
        {
            for (int i = 0; i < quantity; i++)
            {
                Resource resource = ResourceCreator.GenerateResource();
                resource.prefab = Helper.InstantiateObject(resourcePrefab.gameObject);
                PassResourceData(resource);
                resources.Add(resource);
            }
        }

        private static void PassResourceData(Resource resource)
        {
            ResourceBehaviour resourceBehaviour = resource.prefab.GetComponent<ResourceBehaviour>();
            if (resourceBehaviour != null)
            {
                resourceBehaviour.InitializeResource(resource);
            }
        }
    }
}