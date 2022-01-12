using UnityEngine;

namespace Home
{
    public class Character : Entity
    {
        public static float speed;
        public float speedMultiplier;
        public float damageMultiplier;
        public GameObject prefab;

        public Character() { }

        public Character(float healthLimit, float health, float baseDamage, string name, float speedMultiplier) : base(healthLimit, health, baseDamage, name)
        {
            this.speedMultiplier = speedMultiplier;
        }
    }
}
