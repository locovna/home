using UnityEngine;

namespace Home
{
    public class CharacterAnimation : MonoBehaviour
    {
        private void PlayIdleAnimation()
        {
            float x = transform.position.x;
            float z = transform.position.z;
            transform.position = new Vector3(x, (Mathf.Sin(Time.time) + 12) / 7, z);
        }
    }
}