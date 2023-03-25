using Home;
using UnityEngine;

namespace ProjectHome.Data
{
    [CreateAssetMenu(menuName = "Home/Data Containers/" + nameof(CoreGameDataContainer),
        fileName = nameof(CoreGameDataContainer))]
    public class CoreGameDataContainer : ScriptableObject
    {
        [SerializeField] private CharacterBehaviour _characterPrefab;
        [SerializeField] private ResourceBehaviour _resourcePrefab;

        public CharacterBehaviour CharacterBehaviour => _characterPrefab;
        public ResourceBehaviour ResourcePrefab => _resourcePrefab;
    }
}