using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public int id;
    public float healthLimit;
    public float health;
    public float baseDamage;
    public string name;
    public Vector3 coordinates;

    public Entity(float healthLimit, float health, float baseDamage, string name)
    {
        this.id = Random.Range(0,1000);
        this.healthLimit = healthLimit;
        this.health = health; // make check if health <= health limit
        this.baseDamage = baseDamage;
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

class Example
{
    [RuntimeInitializeOnLoadMethod]
    static void Main()
    {
        var testEntity = new Entity(100f, 100f, 10f, "Prikolchik");
        testEntity.Heal(50);
        testEntity.TakeDamage(5);
        Debug.Log($"Hey, {testEntity.name} #{testEntity.id} your health is {testEntity.health}, but base damage is {testEntity.baseDamage}.");
    }
}
