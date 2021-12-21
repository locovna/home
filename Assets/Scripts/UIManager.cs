using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public bool cheatMode = true;
    public GameObject MainBar;

    // todo: to find out more elegant way
    public TextMeshProUGUI healthBar;
    public GameObject character; 
    private CharacterHealth characterHealth;
    private string health;

    void Start()
    {   
        characterHealth = character.GetComponent<CharacterHealth>();
    }

    void Update()
    {
        // todo: move to separate method
        if(cheatMode)
            MainBar.SetActive(true);
        else
            MainBar.SetActive(false);
        
        health = (int)characterHealth.health + "";
        UpdateText(healthBar, health);
    }

    void UpdateText(TextMeshProUGUI textMeshProObject, string text)
    {
        textMeshProObject.text = text;
    }
}
