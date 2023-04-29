using System;
using UnityEngine;

namespace Home
{
    public class ResourceBehaviour : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Color _activeColor;

        private Color _initialColor;
        private bool _isSelected;
        private BaseResource _resource;

        public string ResourceName => _resource.Name;
        public event Action<CharacterEntity> OnApply;

        private void Awake()
        {
            _initialColor = _renderer.material.color;
        }

        public void SwitchSelectedState()
        {
            _isSelected = !_isSelected;
            _renderer.material.color = _isSelected ? _activeColor : _initialColor;
        }

        public void Init(BaseResource resource)
        {
            _resource = resource;
        }

        public void Apply(CharacterEntity characterEntity)
        {
            _resource.Apply(characterEntity);
            OnApply?.Invoke(characterEntity);
        }
    }
}