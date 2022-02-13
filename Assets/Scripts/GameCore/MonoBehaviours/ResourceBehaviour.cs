using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class ResourceBehaviour : MonoBehaviour
    {
        public Resource resource;
        public bool active = false;

        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.ForceSoftware;
        public Vector2 hotSpot = Vector2.zero;

        Color colorHower = Color.red;
        Color colorClicked = Color.green;
        Color colorInitial;
        Renderer rendererComponent;

        void Start()
        {
            rendererComponent = GetComponent<Renderer>();
            colorInitial = rendererComponent.material.GetColor("_Color");
        }

        void OnMouseEnter()
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        void OnMouseExit()
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
            if (active == false)
            {
                rendererComponent.material.color = colorInitial;
            }
        }

        void OnMouseDown()
        {
            if (active == false)
            {
                active = true;
                rendererComponent.material.color = colorClicked;
            }
            else
            {
                active = false;
                rendererComponent.material.color = colorInitial;
            }
        }

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
