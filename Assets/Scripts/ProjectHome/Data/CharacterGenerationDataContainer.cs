using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProjectHome.Data
{
    [CreateAssetMenu(menuName = "Home/Data Containers/" + nameof(CharacterGenerationDataContainer),
        fileName = nameof(CharacterGenerationDataContainer))]
    public class CharacterGenerationDataContainer : ScriptableObject
    {
        [SerializeField] private string[] _names;
        [SerializeField] private float _minHealthLimit;
        [SerializeField] private float _maxHealthLimit;
        [SerializeField] private float _minSelfDamage;
        [SerializeField] private float _maxSelfDamage;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minDamage;
        [SerializeField] private float _maxDamage;
        [SerializeField] private float _minSpeedMultiplier;
        [SerializeField] private float _maxSpeedMultiplier;

        public IEnumerable<string> Names => _names;
        public Tuple<float, float> HealthLimits => new Tuple<float, float>(_minHealthLimit, _maxHealthLimit);
        public Tuple<float, float> SelfDamageLimits => new Tuple<float, float>(_minSelfDamage, _maxSelfDamage);
        public Tuple<float, float> SpeedLimits => new Tuple<float, float>(_minSpeed, _maxSpeed);
        public Tuple<float, float> DamageLimits => new Tuple<float, float>(_minDamage, _maxDamage);

        public Tuple<float, float> SpeedMultiplierLimits =>
            new Tuple<float, float>(_minSpeedMultiplier, _maxSpeedMultiplier);

        private CharacterGenerationDataContainer()
        {
            _names = new string[]
            {
                "Prikolchik",
                "Loshok",
                "Pips",
                "Chelik",
                "Caratel",
                "Ulyot",
                "Chaika",
                "Loh"
            };

            _minHealthLimit = 300f;
            _maxHealthLimit = 500f;
            _minSelfDamage = 0.1f;
            _maxSelfDamage = 1f;
        }

        public string GetRandomName()
        {
            var index = Random.Range(0, _names.Length);
            return _names[index];
        }
    }

    public static class GenerationDataExtensions
    {
        public static float GetRandom(this Tuple<float, float> tuple)
        {
            return Random.Range(tuple.Item1, tuple.Item2);
        }
    }
}