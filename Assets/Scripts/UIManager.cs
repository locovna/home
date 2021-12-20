using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool cheatMode = true;
    public GameObject MainBar;

    void Start()
    {
        
    }

    void Update()
    {
        if(cheatMode)
            MainBar.SetActive(true);
        else
            MainBar.SetActive(false);
    }
}
