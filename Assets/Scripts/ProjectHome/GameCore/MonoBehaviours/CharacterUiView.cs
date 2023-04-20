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

        public void SetName(string characterName)
        {
            _nameLabel.text = characterName;
        }

        public void SetHealthValue(float normalizedHealth)
        {
            _healthBar.fillAmount = normalizedHealth;
        }

        public void SetSelected(bool isSelected)
        {
            _selection.gameObject.SetActive(isSelected);
        }
    }
}