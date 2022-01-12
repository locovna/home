using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public float health = 100f;
    public float baseDamage = 1f;

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            TakeDamage(baseDamage);
        }
    }

    public void TakeDamage(float damagePoints) 
    {
        health -= baseDamage;
    }
}
