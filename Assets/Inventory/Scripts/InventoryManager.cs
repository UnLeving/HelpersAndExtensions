using UnityEngine;

namespace HelpersAndExtensions.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Transform gridTransform;
        [SerializeField] private InventorySlot[] slots;
        [SerializeField] private InventoryItem inventoryItemPrefab;

        private void Awake()
        {
            slots = gridTransform.GetComponentsInChildren<InventorySlot>();
        }

        public bool TryAddItem(ItemSO item)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                var inventoryItem = slots[i].GetComponentInChildren<InventoryItem>();

                if (inventoryItem == null || inventoryItem.ItemSo != item ||
                    inventoryItem.Amount >= inventoryItem.ItemSo.maxStackSize) continue;
                
                inventoryItem.Amount++;

                return true;
            }
            
            for (int i = 0; i < slots.Length; i++)
            {
                var inventoryItem = slots[i].GetComponentInChildren<InventoryItem>();

                if (inventoryItem != null) continue;
                
                SpawnNewItem(item, slots[i]);
                    
                return true;
            }
            
            return false;
        }

        private void SpawnNewItem(ItemSO item, InventorySlot slot)
        {
            var newItem = Instantiate(inventoryItemPrefab, slot.transform);
            
            newItem.Initialize(item);
        }
    }
}