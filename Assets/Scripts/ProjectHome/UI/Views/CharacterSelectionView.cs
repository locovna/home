using System;
using System.Collections.Generic;
using System.Linq;
using ProjectHome.Data;
using ProjectHome.GameCore.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectHome.UI.Views
{
    public class CharacterSelectionView : MonoBehaviour
    {
        [SerializeField] private CharacterManager _characterManager;
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
            _selectionManager.SetCharactersSelected(_characterManager.GetAliveCharacters());
        }

        private void OnClickSelectIdle()
        {
            _selectionManager.SetCharactersSelected(_characterManager.GetAliveCharacters()
                .Where(x => x.CurrentTask == ETaskType.None));
        }
    }
}