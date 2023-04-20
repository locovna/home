using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Home
{
    public enum ETaskType
    {
        None,
        Move,
        Use,
        Store
    }

    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private CharacterManager _characterManager;

        public IEnumerable<CharacterEntity> GetIdleCharacters()
        {
            return _characterManager.GetAliveCharacters().Where(x => x.CurrentTask == ETaskType.None);
        }
    }
}