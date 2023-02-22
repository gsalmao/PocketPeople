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
        private Action<BaseItem> OnHoverItem = delegate { };
        private Action OnExitHoverItem = delegate { };

        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private Image itemIcon;
        [SerializeField] private Button button;

        private BaseItem item;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnPointerEnterCallback += OnPointerEnterItemCallback;
            OnPointerExitCallback += OnExitHoverItem;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            OnPointerEnterCallback -= OnPointerEnterItemCallback;
            OnPointerExitCallback -= OnExitHoverItem;
        }

        public void SetButtonActive(bool value) => button.enabled = value;

        public void OnPointerEnterItemCallback() => OnHoverItem(item);

        #region ItemButton
        /// <summary>
        /// Set the button in any ItemMenu.
        /// </summary>
        /// <param name="item">The item being used.</param>
        /// <param name="OnHoverItem">Callback whenever mouse is over the item.</param>
        /// <param name="OnExitHoverItem">Callback whenever the mouse leaves the item's area.</param>
        public void SetButton(BaseItem item, Action<BaseItem> OnHoverItem, Action OnExitHoverItem)
        {
            this.OnHoverItem = OnHoverItem;
            this.OnExitHoverItem = OnExitHoverItem;

            this.item = item;
            itemName.text = item.ItemName;
            itemIcon.sprite = item.Icon;
            itemIcon.color = Color.white;
        }

        public void ClearButton()
        {
            OnHoverItem = delegate { };
            OnExitHoverItem = delegate { };
            item = null;
            itemName.text = "";
            itemIcon.color = Color.clear;
        }
        #endregion

        #region OnClick
        /// <summary>
        /// Callback to process the item when clicked, which is injected by whoever is using it.
        /// </summary>
        /// <param name="callback"></param>
        public void SetOnClick(Action<BaseItem> callback) => button.onClick.AddListener(delegate { callback(item); });
        public void ClearOnClick() => button.onClick.RemoveAllListeners();
        #endregion
    }
}
