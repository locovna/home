using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class ResourceBehaviour : MonoBehaviour
    {
       // public Resource resource;
        public bool active = false;

        public delegate void ResourceActivationDelegate();
        public event ResourceActivationDelegate Canceled;

        Color colorClicked = Color.green;
        Color colorInitial;
        Renderer rendererComponent;

        void Start()
        {
            rendererComponent = GetComponent<Renderer>();
            colorInitial = rendererComponent.material.GetColor("_Color");
        }

        public void ClickOnResource()
        {
            if (!active)
            {
                active = true;
                rendererComponent.material.color = colorClicked;
            }
            else 
            {
                active = false;
                rendererComponent.material.color = colorInitial;
                Canceled?.Invoke();
            }
        }

        // public void InitializeResource(Resource resourceToInitialize)
        // {
        //     resource = resourceToInitialize;
        // }
        //
        // public void ApplyEffects(Character character)
        // {
        //     resource.ApplyEffects(character);
        // }
    }
}
