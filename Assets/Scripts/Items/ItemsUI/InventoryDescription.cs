using System;
using TMPro;
using UnityEngine;

namespace PocketPeople.Items.UI
{
    /// <summary>
    /// Draws the item description in the description window. Uses a static method to prevent the need of referencing inside buttons.
    /// </summary>
    internal class InventoryDescription : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemDescription;

        private static event Action<BaseItem> OnShowDescription = delegate { };

        private void OnEnable() => OnShowDescription += Show;
        private void OnDisable() => OnShowDescription -= Show;

        internal static void ShowDescription(BaseItem item) => OnShowDescription(item);

        private void Show(BaseItem item)
        {
            if(item)
            {
                itemName.text = item.ItemName;
                itemDescription.text = item.Description;
            }
            else
            {
                itemName.text = "";
                itemDescription.text = "";
            }
        }
    }
}
