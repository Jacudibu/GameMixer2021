using UnityEngine;

namespace Utility
{
    public class DestroyOnAwake : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}
