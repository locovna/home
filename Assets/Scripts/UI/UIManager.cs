using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject MainBar;
    public TextMeshProUGUI healthBar;

    void Update()
    {
        UpdateText(healthBar, "000");
    }

    void UpdateText(TextMeshProUGUI textMeshProObject, string text)
    {
        textMeshProObject.text = text;
    }
}
