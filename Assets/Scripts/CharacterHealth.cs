using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthLimit = 100f;
    public float health = 100f;
    public float universalBaseDamage = 0.01f;

    private Scene scene;

    // todo: remove the test
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if(health <= 0)
        {
            // todo: implement death screen
            SceneManager.LoadScene(scene.name);
        }
        else
        {
            // take damage overtime
            TakeDamage(universalBaseDamage);
        }

        // todo: remove the test
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
        UpdateHealthBar();
    }

    public void Healing(float healPoints)
    {
        health += healPoints;
        health = Mathf.Clamp(health, 0, healthLimit);
        UpdateHealthBar();
    }

    // todo: separate UI logic
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = health / healthLimit;
    }    
}
