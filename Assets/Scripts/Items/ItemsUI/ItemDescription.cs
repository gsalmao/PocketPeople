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

        public void ShowDescription(BaseItem item)
        {
            itemName.text = item.ItemName;
            itemDescription.text = item.Description;
        }

        public void HideDescription()
        {
            itemName.text = "";
            itemDescription.text = "";
        }
    }
}
