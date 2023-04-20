using System;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Home
{
    public class CharacterProperties : MonoBehaviour
    {
        private float _healthLimit;
        private float _selfDamage;
        private float _speed;
        private float _speedMultiplier;
        private float _damageMultiplier;
        private float _health;

        public event Action OnDeath;

        // public void Heal(float healingPoints)
        // {
        //     _health += healingPoints;
        //     _health = Mathf.Clamp(_health, 0, _healthLimit);
        // }

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