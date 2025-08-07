using UnityEngine;

namespace Helpers.Extensions
{
    public static class TransformExtensions
    {
        public static Vector3 DirectionTo(this Transform transform, Transform target)
        {
            return (target.position - transform.position).normalized;
        }
    }
}