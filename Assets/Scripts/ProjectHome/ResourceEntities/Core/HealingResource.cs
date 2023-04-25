using Home;
using UnityEngine;

namespace ProjectHome.ResourceEntities.Core
{
    [CreateAssetMenu(menuName = "Home/Resources/" + nameof(HealingResource),
        fileName = "New " + nameof(HealingResource))]
    public class HealingResource : BaseResource<float>
    {
        public override void Apply(CharacterEntity characterEntity)
        {
            characterEntity.Heal(Value);
        }
    }
}