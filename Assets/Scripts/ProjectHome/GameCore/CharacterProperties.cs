using System;
using UnityEngine;

namespace Home
{
    public class CharacterProperties : MonoBehaviour
    {
        private float _health;
        private float _healthLimit;
        private float _selfDamage;
        private float _speed;
        private float _speedMultiplier;
        private float _damageMultiplier;

        public event Action OnDeath;
        public float NormalizedHealth => _health / _healthLimit;

        public void Heal(float healingPoints)
        {
            _health = Mathf.Clamp(_health + healingPoints, 0, _healthLimit);
        }

        public void TakeDamage(float deltaTime)
        {
            if (_health <= 0f)
                return;

            _health -= _selfDamage * deltaTime;

            if (_health > 0)
                return;

            OnDeath?.Invoke();
        }

        public void Init(float healthLimit, float selfDamage, float speed, float speedMultiplier,
            float damageMultiplier)
        {
            _healthLimit = healthLimit;
            _health = healthLimit;
            _selfDamage = selfDamage;
            _speed = speed;
            _speedMultiplier = speedMultiplier;
            _damageMultiplier = damageMultiplier;
        }
    }
}