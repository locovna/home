using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthLimit = 100;
    public float health = 100;

    void Update()
    {
        if(health <= 0)
        {
            // restart application
            // todo: use SceneManager.LoadScene
            // Application.LoadLevel(Application.loadedLevel);
        }

        // todo: remove the example
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
            UpdateHealthBar();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Healing(10);
            UpdateHealthBar();
        }
    }

    public void TakeDamage(float damagePoints) 
    {
        health -= damagePoints;
    }

    public void Healing(float healPoints)
    {
        health += healPoints;
        health = Mathf.Clamp(health, 0, healthLimit);
    }

    // todo: separate UI logic
    // fix: reference error
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = health / healthLimit;
    }    
}
