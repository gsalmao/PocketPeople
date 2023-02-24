using PocketPeople.CursorEntities;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PocketPeople.Items.UI
{
    /// <summary>
    /// ItemButton prefab. The functionality is injected.
    /// </summary>
    public class ItemButton : CursorModifier
    {
        private Action<RuntimeItem> OnHoverItem = delegate { };
        private Action OnExitHoverItem = delegate { };

        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private Image itemIcon;
        [SerializeField] private Button button;

        private RuntimeItem item;

        public RuntimeItem Item => item;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnPointerEnterCallback += OnPointerEnterItemCallback;
            OnPointerExitCallback += OnPointerExitItemCallback;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            OnPointerEnterCallback -= OnPointerEnterItemCallback;
            OnPointerExitCallback -= OnPointerExitItemCallback;
        }

        public void SetButtonActive(bool value) => button.enabled = value;
        public void OnPointerEnterItemCallback() => OnHoverItem(item);
        public void OnPointerExitItemCallback() => OnExitHoverItem();

        #region ItemButton
        /// <summary>
        /// Set the button in the ItemMenu.
        /// </summary>
        /// <param name="item">The item being used.</param>
        /// <param name="OnHoverItem">Callback whenever mouse is over the item.</param>
        /// <param name="OnExitHoverItem">Callback whenever the mouse leaves the item's area.</param>
        /// <param name="OnClickItem">Callback whenever the item is clicked.</param>
        public void SetButton(ItemButton itemButton, RuntimeItem item, Action<RuntimeItem> OnHoverItem, Action OnExitHoverItem, Action<ItemButton> OnClickItem)
        {
            this.OnHoverItem = OnHoverItem;
            this.OnExitHoverItem = OnExitHoverItem;
            button.onClick.AddListener(delegate { OnClickItem(itemButton); });

            this.item = item;
            itemName.text = item.ItemData.ItemName;
            itemIcon.sprite = item.ItemData.Icon;
            itemIcon.color = Color.white;
        }

        public void ClearButton()
        {
            OnHoverItem = delegate { };
            OnExitHoverItem = delegate { };
            button.onClick.RemoveAllListeners();

            item = null;
            itemName.text = "";
            itemIcon.color = Color.clear;
        }
        #endregion
    }
}
