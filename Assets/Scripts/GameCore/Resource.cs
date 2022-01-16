using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class Resource : Entity
    {
        public GameObject prefab;
        public Dictionary<string, float> effects { get; protected set; } = new Dictionary<string, float>();

        public Resource() { }

        public Resource(float healthLimit, float health, float selfDamage, string name)
        : base(healthLimit, health, selfDamage, name) { }

        public Resource(float healthLimit, float health, float selfDamage, string name, Dictionary<string, float> effects)
        : base(healthLimit, health, selfDamage, name) { }

        public void ApplyEffects(Character character)
        {
            character.Heal(100f);
            Debug.Log($"{character.name} was affected by {name}");
        }
    }

    public static class ResourceCreator
    {
        static private string[] RandomNames =
                {"Strawberry", "Tomato",
                "Snake", "Angel's Tears",
                "Old Shoe", "Drugs",
                "Chelik's hair", "Newspaper"};

        private static Dictionary<string, float> effects = new Dictionary<string, float>()
        {
            {"heal", 10f},
            {"damage", 10f},
            {"change name", 1f},
            {"kill", 1f},
            {"pregnant", 1f}
        };

        public static Resource GenerateResource()
        {
            string name = RandomNames[Random.Range(0, RandomNames.Length - 1)];
            float randomHealthLimit = Random.Range(100f, 500f);
            float randomSelfDamage = Random.Range(0f, 1f);

            Resource generatedResource = new Resource(randomHealthLimit, randomHealthLimit, randomSelfDamage, name, effects);
            return generatedResource;
        }
    }
}
