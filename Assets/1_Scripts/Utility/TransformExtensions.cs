using JetBrains.Annotations;
using UnityEngine;

namespace Utility
{
    public static class TransformExtensions
    {
        public static void DeleteAllChildren([NotNull] this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                Object.Destroy(child.gameObject);
            }
        }
    }
}