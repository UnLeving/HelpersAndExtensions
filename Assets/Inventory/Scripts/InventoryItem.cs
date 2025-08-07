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
        
        private Transform _parentAfterDrag;
        private Image _image;
        private int _amount = 1;
        
        public ItemSO ItemSo {get; private set;}
        
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;

                UpdateText();
            }
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        public void Initialize(ItemSO item)
        {
            this.ItemSo = item;
            _image.sprite = item.icon;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _parentAfterDrag = transform.parent;

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
            transform.SetParent(_parentAfterDrag);

            _image.raycastTarget = true;
        }

        private void UpdateText()
        {
            if (Amount > 1)
            {
                amountText.text = Amount.ToString();
            }
        }

        public void SetParentAfterDrag(Transform parent)
        {
            _parentAfterDrag = parent;
        }
    }
}