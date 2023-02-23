using System;
using TMPro;
using UnityEngine;

namespace PocketPeople.Items.UI
{
    /// <summary>
    /// Shows the description of an item.
    /// </summary>
    public class ItemDescription : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemDescription;

        public void ShowDescription(RuntimeItem item)
        {
            itemName.text = item.ItemData.ItemName;
            itemDescription.text = item.ItemData.Description;
        }

        public void HideDescription()
        {
            itemName.text = "";
            itemDescription.text = "";
        }
    }
}
