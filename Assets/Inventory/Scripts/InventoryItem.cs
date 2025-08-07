using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HelpersAndExtensions.Inventory
{
    [RequireComponent(typeof(Image))]
    public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private TextMeshProUGUI amountText;
        [HideInInspector] public Transform parentAfterDrag;
        public int amount = 1;
        private Image _image;
        public ItemSO item;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            parentAfterDrag = transform.parent;

            transform.SetParent(transform.root);
            transform.SetAsLastSibling();

            _image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(parentAfterDrag);

            _image.raycastTarget = true;
        }

        public void Initialize(ItemSO item)
        {
            this.item = item;
            _image.sprite = item.icon;
        }

        private void UpdateText()
        {
            if(amount > 1)
            {
                amountText.text = amount.ToString();
            }
        }
    }
}