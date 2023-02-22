using PocketPeople.CursorEntities;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PocketPeople.Items
{
    public class ItemButton : CursorModifier
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private Image itemIcon;
        [SerializeField] private Button button;

        private BaseItem item;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnPointerEnterCallback += ShowButtonItem;
            OnPointerExitCallback += HideButtonItem;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            OnPointerEnterCallback -= ShowButtonItem;
            OnPointerExitCallback -= HideButtonItem;
        }

        public void SetButtonActive(bool value) => button.enabled = value;

        #region ItemButton
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
        #endregion

        #region OnClick
        public void SetOnClick(Action<BaseItem> callback) => button.onClick.AddListener(delegate { callback(item); });
        public void ClearOnClick() => button.onClick.RemoveAllListeners();
        #endregion

        private void ShowButtonItem() => InventoryDescription.ShowDescription(item);
        private void HideButtonItem() => InventoryDescription.ShowDescription(null);
    }
}
