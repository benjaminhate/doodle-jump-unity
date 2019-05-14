using Tools;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Doodle/Item")]
    public class Item : ScriptableObject
    {
        public GameObject prefab;
        [MinMaxRange(-1f, 1f)]
        public RangedFloat xRange;
    }
}
