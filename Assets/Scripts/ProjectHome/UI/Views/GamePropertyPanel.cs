using TMPro;
using UnityEngine;

namespace ProjectHome.UI.Views
{
    public class GamePropertyPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _daysAliveText;
        [SerializeField] private TextMeshProUGUI _colonySizeText;
        [SerializeField] private TextMeshProUGUI _foodText;

        public void SetDaysAliveText(string text)
        {
            _daysAliveText.text = text;
        }

        public void SetColonySizeText(string text)
        {
            _colonySizeText.text = text;
        }

        public void SetFoodAmountText(int amount)
        {
            _foodText.text = amount.ToString();
        }

        // IEnumerator DaysCountingCoroutine()
        // {
        //     WaitForSeconds wait = new WaitForSeconds(20);
        //
        //     while (true)
        //     {
        //         days += 1;
        //         yield return wait;
        //     }
        // }
    }
}