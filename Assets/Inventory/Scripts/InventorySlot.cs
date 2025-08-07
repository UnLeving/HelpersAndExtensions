using UnityEngine;
using UnityEngine.EventSystems;

namespace HelpersAndExtensions.Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            var obj = eventData.pointerDrag;
            var inventoryItem = obj.GetComponent<InventoryItem>();
            
            inventoryItem.parentAfterDrag = transform;
        }
    }
}