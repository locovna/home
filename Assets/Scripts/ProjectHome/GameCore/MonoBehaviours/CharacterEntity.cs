using System;
using UnityEngine;

namespace Home
{
    public class CharacterEntity : MonoBehaviour
    {
        [SerializeField] private CharacterProperties _characterProperties;
        [SerializeField] private CharacterBehaviour _characterBehaviour;
        [SerializeField] private MovementController _movementController;

        private InputManager _inputManager;
        private int _id;
        private bool _isInitialized;

        public int Id => _id;

        public event Action<int> OnDeath;

        private void OnEnable()
        {
            _characterProperties.OnDeath += OnDeathHandler;

            if (_isInitialized)
                SubscribeToClick();
        }

        private void OnDisable()
        {
            _characterProperties.OnDeath -= OnDeathHandler;

            UnsubscribeFromClick();
        }

        private void OnDeathHandler()
        {
            OnDeath?.Invoke(_id);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Resource"))
                return;

            var resourceBehaviour = other.GetComponent<ResourceBehaviour>();
            _characterBehaviour.ResourceInteract(resourceBehaviour, TaskManager.currentTask);
        }

        public void Init(int id, float healthLimit, float selfDamage, float speed, float speedMultiplier,
            float damageMultiplier, InputManager inputManager)
        {
            _id = id;
            _characterProperties.Init(healthLimit, selfDamage, speed, speedMultiplier, damageMultiplier);
            _inputManager = inputManager;
            SubscribeToClick();
            _isInitialized = true;
        }

        private void SubscribeToClick()
        {
            _inputManager.OnPointerClick += OnPointerClickHandler;
        }

        private void UnsubscribeFromClick()
        {
            _inputManager.OnPointerClick -= OnPointerClickHandler;
        }

        private void OnPointerClickHandler(Vector3 point)
        {
            _movementController.MoveTo(point);
        }

        public virtual void Tick(float deltaTime)
        {
            _characterProperties.TakeDamage(deltaTime);
        }
    }
}