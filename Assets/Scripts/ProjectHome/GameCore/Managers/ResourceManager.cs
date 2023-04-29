using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHome.ResourceEntities;
using UnityEngine;

namespace ProjectHome.GameCore.Managers
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private BaseResource[] _resources;

        private List<ResourceBehaviour> _registeredResources;

        public event Action<int, int> OnResourceAmountChanged;

        private ResourceManager()
        {
            _registeredResources = new List<ResourceBehaviour>();
        }

        public IEnumerable<ResourceBehaviour> GenerateResources(int quantity, ResourceBehaviour resourcePrefab)
        {
            var resources = new ResourceBehaviour[quantity];

            for (int i = 0; i < quantity; i++)
            {
                var resourceInstance = Instantiate(resourcePrefab);
                resourceInstance.Init(_resources.First());
                resources[i] = resourceInstance;
            }

            return resources;
        }

        public void RegisterResourceInstances(ResourceBehaviour[] resources)
        {
            foreach (var resource in resources)
            {
                resource.OnApply += _ =>
                {
                    var initialCount = _registeredResources.Count;
                    _registeredResources.Remove(resource);
                    OnResourceAmountChanged?.Invoke(initialCount, _registeredResources.Count);
                };
            }

            _registeredResources.AddRange(resources);
        }
    }
}