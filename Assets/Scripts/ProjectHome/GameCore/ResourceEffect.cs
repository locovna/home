using System;
using UnityEngine;

namespace Home
{
    [Serializable]
    public abstract class ResourceEffect
    {
        [SerializeField] private string _name;

        public abstract void Apply(CharacterEntity characterEntity);
    }

    [Serializable]
    public abstract class ResourceEffect<T> : ResourceEffect
    {
        [SerializeField] private T _value;
    }
}