using System;
using UnityEngine;

namespace Home
{
    public class CharacterEntity : MonoBehaviour
    {
        [SerializeField] private CharacterProperties _characterProperties;
        [SerializeField] private CharacterBehaviour _characterBehaviour;
        [SerializeField] private MovementController _movementController;
        [SerializeField] private CharacterUiView _characterUiView;

        private int _id;
        private bool _isSelected;

        public int Id => _id;
        public ETaskType CurrentTask { get; set; } = ETaskType.None;
        public bool IsSelected => _isSelected;

        public event Action<CharacterEntity> OnDeath;

        private void OnEnable()
        {
            SetSelected(false);
            _characterProperties.OnDeath += OnDeathHandler;
        }

        private void OnDisable()
        {
            _characterProperties.OnDeath -= OnDeathHandler;
        }

        private void OnDeathHandler()
        {
            OnDeath?.Invoke(this);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Resource"))
                return;

            var resourceBehaviour = other.GetComponent<ResourceBehaviour>();
            _characterBehaviour.ResourceInteract(resourceBehaviour, CurrentTask, this);
        }

        public void Init(int id, float healthLimit, float selfDamage, float speed, float speedMultiplier,
            float damageMultiplier, string characterName)
        {
            _id = id;
            _characterProperties.Init(healthLimit, selfDamage, speed, speedMultiplier, damageMultiplier);
            name = $"{characterName} [{id}]";
            _characterUiView.SetName(characterName);
        }

        public virtual void Tick(float deltaTime)
        {
            _characterProperties.TakeDamage(deltaTime);
            _characterUiView.SetHealthValue(_characterProperties.NormalizedHealth);
        }

        public void MoveTo(Vector3 point)
        {
            _movementController.MoveTo(point);
        }

        public void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;
            _characterUiView.SetSelected(_isSelected);
        }
    }
}