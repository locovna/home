using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class ResourceBehaviour : MonoBehaviour
    {
        private Resource resource;

        public void InitializeResource(Resource resourceToInitialize)
        {
            resource = resourceToInitialize;
        }

        public void ApplyEffects(Character character)
        {
            resource.ApplyEffects(character);
        }
    }
}
