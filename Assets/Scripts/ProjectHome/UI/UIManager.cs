using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Home
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI colonySizeText;
        public TextMeshProUGUI daysAliveText;
        private int days = 0;

        void Start()
        {
            StartCoroutine(DaysCountingCoroutine());
        }

        void Update()
        {
            UpdateText(colonySizeText, CharacterManager.characterList.Count.ToString());
            UpdateText(daysAliveText, days.ToString());
        }

        void UpdateText(TextMeshProUGUI textMeshProObject, string text)
        {
            textMeshProObject.text = text;
        }

        IEnumerator DaysCountingCoroutine()
        {
            WaitForSeconds wait = new WaitForSeconds(20);
 
            while(true)
            {
                days += 1;
                yield return wait;
            }
        }
    }
}
