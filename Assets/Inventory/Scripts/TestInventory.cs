using UnityEngine;

namespace HelpersAndExtensions.Inventory
{
    public class TestInventory : MonoBehaviour
    {
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private ItemSO[] items;
        
        public void AddItem(int btnIndex)
        {
            inventoryManager.TryAddItem(items[btnIndex]);
        }
    }
}