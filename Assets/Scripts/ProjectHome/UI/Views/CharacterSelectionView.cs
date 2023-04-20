using System;
using System.Collections.Generic;
using Home;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectHome.UI.Views
{
    public class CharacterSelectionView : MonoBehaviour
    {
        [SerializeField] private TaskManager _taskManager;
        [SerializeField] private SelectionManager _selectionManager;
        [SerializeField] private Button _buttonSelectAll;
        [SerializeField] private Button _buttonSelectIdle;

        private void OnEnable()
        {
            _buttonSelectAll.onClick.AddListener(OnClickSelectAll);
            _buttonSelectIdle.onClick.AddListener(OnClickSelectIdle);
        }

        private void OnDisable()
        {
            _buttonSelectAll.onClick.RemoveListener(OnClickSelectAll);
            _buttonSelectIdle.onClick.RemoveListener(OnClickSelectIdle);
        }

        private void OnClickSelectAll()
        {
            Debug.Log("Select All");
        }

        private void OnClickSelectIdle()
        {
            _selectionManager.SetCharactersSelected(_taskManager.GetIdleCharacters());
        }
    }
}