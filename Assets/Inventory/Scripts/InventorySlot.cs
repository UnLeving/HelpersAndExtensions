using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            var obj = eventData.pointerDrag;
            var draggableItem = obj.GetComponent<DraggableItem>();
            
            draggableItem.parentAfterDrag = transform;
        }
    }
}