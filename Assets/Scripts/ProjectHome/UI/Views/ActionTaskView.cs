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
        [SerializeField] private SelectionManager _selectionManager;

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

        private void SetTaskForSelectedCharacters(ETaskType taskType)
        {
            foreach (var character in _selectionManager.SelectedCharacters)
            {
                character.CurrentTask = taskType;
            }
        }

        private void OnEatButtonClick()
        {
            SetTaskForSelectedCharacters(ETaskType.Use);
        }

        private void OnStoreButtonClick()
        {
            SetTaskForSelectedCharacters(ETaskType.Store);
        }

        private void OnMoveButtonClick()
        {
            SetTaskForSelectedCharacters(ETaskType.Move);
        }
    }
}