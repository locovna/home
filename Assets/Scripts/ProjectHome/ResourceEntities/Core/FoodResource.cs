using Home;
using UnityEngine;

namespace ProjectHome.ResourceEntities.Core
{
    [CreateAssetMenu(menuName = "Home/Resources/" + nameof(FoodResource),
        fileName = "New " + nameof(FoodResource))]
    public class FoodResource : BaseResource<float>
    {
        public override void Apply(CharacterEntity characterEntity)
        {
            characterEntity.name = Value.ToString();
        }
    }
}