using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Home
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private BaseResource[] _resources;
        [SerializeField] private ObjectDistributionManager _objectDistributionManager;

        public IEnumerable<ResourceBehaviour> GenerateResources(int quantity, ResourceBehaviour resourcePrefab)
        {
            var resources = new ResourceBehaviour[quantity];

            for (int i = 0; i < quantity; i++)
            {
                var resourceInstance = Instantiate(resourcePrefab, _objectDistributionManager.GetRandomPosition(),
                    Quaternion.identity);
                resourceInstance.Init(_resources.First());
                resources[i] = resourceInstance;
            }

            return resources;
        }
    }
}