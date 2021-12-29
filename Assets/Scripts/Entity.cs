using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Home
{
    public class Entity
    {
        public string id { get; protected set; }
        public float healthLimit { get; set; }
        public float selfDamage { get; set; }
        public string name { get; set; }
        private float _health;

        public float health
        {
            get { return _health; }
            set
            {
                if (value <= healthLimit)
                    _health = value;
            }
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
        }

        public void TakeDamage(float damagePoints)
        {
            this.health -= damagePoints;
        }
    }
}

class Example
{
    [RuntimeInitializeOnLoadMethod]
    static void Main()
    {
        var testEntity = new Home.Entity(100f, 100f, 10f, "Prikolchik");
        testEntity.Heal(50);
        testEntity.TakeDamage(5);
        Debug.Log($"Hey, {testEntity.name} #{testEntity.id} your health is {testEntity.health}, but base damage is {testEntity.selfDamage}.");
    }
}
