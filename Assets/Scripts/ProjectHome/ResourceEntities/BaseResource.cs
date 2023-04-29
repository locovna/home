using System;
using UnityEngine;

namespace Home
{
    [Serializable]
    public abstract class BaseResource : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;

        public abstract void Apply(CharacterEntity characterEntity);

        protected void OnValidate()
        {
            if (!string.IsNullOrEmpty(_name))
                return;

            _name = name;
        }
    }

    [Serializable]
    public abstract class BaseResource<T> : BaseResource
    {
        [SerializeField] private T _value;
        public T Value => _value;
    }
}