using UnityEngine;

namespace ProjectHome.GameCore.Managers
{
    public class ObjectDistributionManager : MonoBehaviour
    {
        [SerializeField] private float _spawnRange = 10f;

        public Vector3 GetRandomPosition()
        {
            var randomPosInsideCircle = Random.insideUnitCircle * _spawnRange;
            return new Vector3(randomPosInsideCircle.x, transform.position.y, randomPosInsideCircle.y);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _spawnRange);
        }
    }
}