using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Home
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private float _raycastMaxDistance = 100f;
        [SerializeField] private LayerMask _groundLayerMask;

        public event Action<Vector3> OnPointerClick;
        public event Action<Collider> OnPointerClickCollider;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!Physics.Raycast(GetCameraRay(), out var hitInfo, _raycastMaxDistance, _groundLayerMask))
                return;

            OnPointerClick?.Invoke(hitInfo.point);
            OnPointerClickCollider?.Invoke(hitInfo.collider);
        }

        private Ray GetCameraRay()
        {
            return _gameCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}