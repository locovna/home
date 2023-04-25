using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Home
{
    public class CharacterUiView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private Image _healthBar;
        [SerializeField] private Renderer _selection;
        [SerializeField] private Gradient _healthGradient;

        public void SetName(string characterName)
        {
            _nameLabel.text = characterName;
        }

        public void SetHealthValue(float normalizedHealth)
        {
            _healthBar.fillAmount = normalizedHealth;
            _healthBar.color = _healthGradient.Evaluate(normalizedHealth);
        }

        public void SetSelected(bool isSelected)
        {
            _selection.gameObject.SetActive(isSelected);
        }
    }
}