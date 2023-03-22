using Home;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectHome.UI.Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(LoadScene);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(LoadScene);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(Constants.GameSceneName);
        }
    }
}