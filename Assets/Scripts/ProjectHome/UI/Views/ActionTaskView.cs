using Home;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectHome.UI.Views
{
    public class ActionTaskView : MonoBehaviour
    {
        [SerializeField] private Button _buttonEat;
        [SerializeField] private Button _buttonStore;
        [SerializeField] private Button _buttonMove;

        private void OnEnable()
        {
            _buttonEat.onClick.AddListener(OnEatButtonClick);
            _buttonStore.onClick.AddListener(OnStoreButtonClick);
            _buttonMove.onClick.AddListener(OnMoveButtonClick);
        }

        private void OnDisable()
        {
            _buttonEat.onClick.RemoveListener(OnEatButtonClick);
            _buttonStore.onClick.RemoveListener(OnStoreButtonClick);
            _buttonMove.onClick.RemoveListener(OnMoveButtonClick);
        }

        private void OnEatButtonClick()
        {
            TaskManager.currentTask = "EAT";
        }

        private void OnStoreButtonClick()
        {
            TaskManager.currentTask = "STORE";
        }

        private void OnMoveButtonClick()
        {
            TaskManager.currentTask = "MOVE";
        }
    }
}