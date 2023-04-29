using System;
using UnityEngine;

namespace Home
{
    public class CharacterEntity : MonoBehaviour
    {
        [SerializeField] private CharacterProperties _characterProperties;
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

        public void Init(int id, float healthLimit, float selfDamage, float speed,
            float damageMultiplier, string characterName)
        {
            _id = id;
            _characterProperties.Init(healthLimit, selfDamage, damageMultiplier);
            name = $"{characterName} [{id}]";
            _characterUiView.SetName(characterName);
            _movementController.Speed = speed;
        }

        public virtual void Tick(float deltaTime)
        {
            _characterProperties.TakeDamage(deltaTime);
            _characterUiView.SetHealthValue(_characterProperties.NormalizedHealth);

            if (CurrentTask != ETaskType.None)
            {
                _characterUiView.SetPath(_movementController.GetPath());
            }
        }

        public void MoveTo(Collider other)
        {
            if (!other.CompareTag("Resource"))
                return;

            if (!other.TryGetComponent<ResourceBehaviour>(out var resourceBehaviour))
                return;

            switch (CurrentTask)
            {
                case ETaskType.None:
                    return;

                case ETaskType.Use:
                    UseResource(resourceBehaviour);
                    break;

                case ETaskType.Store:
                    StoreResource(resourceBehaviour);
                    break;

                case ETaskType.Move:
                    MoveToResource(resourceBehaviour);
                    break;
            }
        }

        private void UseResource(ResourceBehaviour resourceBehaviour)
        {
            _movementController.MoveTo(resourceBehaviour.transform.position, () =>
            {
                resourceBehaviour.Apply(this);
                resourceBehaviour.gameObject.SetActive(false);
                CurrentTask = ETaskType.None;
            });
        }

        private void StoreResource(ResourceBehaviour resourceBehaviour)
        {
            // TODO
        }

        private void MoveToResource(ResourceBehaviour resourceBehaviour)
        {
            // TODO
        }

        public void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;
            _characterUiView.SetSelected(_isSelected);
        }

        public void Heal(float value)
        {
            _characterProperties.Heal(value);
        }
    }
}