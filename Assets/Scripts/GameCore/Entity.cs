using UnityEngine;

namespace Home
{
    public class Entity
    {
        public string id { get; protected set; }
        public float healthLimit { get; protected set; }
        public float selfDamage { get; protected set; }
        public string name { get; protected set; }
        public float health { get; protected set; }

        public delegate void DeathDelegate(string id);
        public event DeathDelegate Death;

        public Entity() 
        {
            this.id = Helper.GenerateGUID();
        }

        public Entity(float healthLimit, float health, float selfDamage, string name)
        {
            this.id = Helper.GenerateGUID();
            this.healthLimit = healthLimit;
            this.health = health;
            this.selfDamage = selfDamage;
            this.name = name;
        }

        public void Heal(float healingPoints)
        {
            this.health += healingPoints;
            this.health = Mathf.Clamp(health, 0, healthLimit);
        }

        public void TakeDamage(float damagePoints)
        {
            this.health -= damagePoints;
            if (this.health <= 0)
                Death?.Invoke(this.id);
        }
    }
}
