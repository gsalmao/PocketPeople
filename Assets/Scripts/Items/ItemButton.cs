using PocketPeople.CursorEntities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PocketPeople.Items
{
    public class ItemButton : CursorModifier
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private Image itemIcon;

        private BaseItem item;

        private void OnEnable()
        {
            OnPointerEnterCallback += ShowButtonItem;
            OnPointerExitCallback += HideButtonItem;
        }

        private void OnDisable()
        {
            OnPointerEnterCallback -= ShowButtonItem;
            OnPointerExitCallback -= HideButtonItem;
        }

        public void SetButton(BaseItem item)
        {
            this.item = item;
            itemName.text = item.ItemName;
            itemIcon.sprite = item.Icon;
            itemIcon.color = Color.white;
        }

        public void ClearButton()
        {
            item = null;
            itemName.text = "";
            itemIcon.color = Color.clear;
        }

        private void ShowButtonItem() => InventoryDescription.ShowDescription(item);
        private void HideButtonItem() => InventoryDescription.ShowDescription(null);
    }
}
