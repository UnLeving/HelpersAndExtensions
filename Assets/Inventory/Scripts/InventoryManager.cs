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

                if (inventoryItem == null)
                {
                    SpawnNewItem(item, slots[i]);
                    
                    Debug.Log($"Added item {item.name} to slot {i}");

                    return true;
                }
            }
            
            Debug.LogWarning($"No free slots for item {item.name}");
            
            return false;
        }

        private void SpawnNewItem(ItemSO item, InventorySlot slot)
        {
            var newItem = Instantiate(inventoryItemPrefab, slot.transform);
            
            newItem.Initialize(item);
        }
    }
}