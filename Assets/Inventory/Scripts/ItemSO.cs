using UnityEngine;

namespace HelpersAndExtensions.Inventory
{
    [CreateAssetMenu(menuName = "SO/Inventory/Item")]
    public class ItemSO : ScriptableObject
    {
        public Sprite icon;
        public int maxStackSize = 1;
    }
}