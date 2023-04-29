using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectHome.GameCore.Character
{
    public class CharacterUiView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private Image _healthBar;
        [SerializeField] private Renderer _selection;
        [SerializeField] private Gradient _healthGradient;
        [SerializeField] private LineRenderer _lineRenderer;

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

        public void SetPath(IEnumerable<Vector3> points)
        {
            var path = points.ToArray();
            _lineRenderer.positionCount = path.Length;
            _lineRenderer.SetPositions(path);
        }
    }
}