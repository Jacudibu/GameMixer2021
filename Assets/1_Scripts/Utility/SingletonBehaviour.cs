using UnityEngine;

namespace Utility
{
    public class SingletonBehaviour<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        public static T Instance;

        public SingletonBehaviour()
        {
            Instance = this as T;
        }
    }
}