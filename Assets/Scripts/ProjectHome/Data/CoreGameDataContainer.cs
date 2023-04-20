using Home;
using UnityEngine;

namespace ProjectHome.Data
{
    [CreateAssetMenu(menuName = "Home/Data Containers/" + nameof(CoreGameDataContainer),
        fileName = nameof(CoreGameDataContainer))]
    public class CoreGameDataContainer : ScriptableObject
    {
        [SerializeField] private CharacterEntity _characterEntity;
        [SerializeField] private ResourceBehaviour _resourcePrefab;

        public CharacterEntity CharacterBehaviour => _characterEntity;
        public ResourceBehaviour ResourcePrefab => _resourcePrefab;
    }
}