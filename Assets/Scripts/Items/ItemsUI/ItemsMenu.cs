using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace PocketPeople.Items.UI
{
    /// <summary>
    /// Item Menu's object pooling system.
    /// </summary>
    public class ItemsMenu : MonoBehaviour
    {
        [SerializeField, FoldoutGroup("References")] private Transform inventoryContent;
        [SerializeField, FoldoutGroup("References")] private ItemButton itemButtonPrefab;
        public List<ItemButton> ItemButtons => itemButtons;

        private ObjectPool<ItemButton> buttonsPool;
        private List<ItemButton> itemButtons;


        public void Init()
        {
            buttonsPool = new ObjectPool<ItemButton>(
            () => Instantiate(itemButtonPrefab),
            button => button.gameObject.SetActive(true),
            button => button.gameObject.SetActive(false),
            button => Destroy(button), false, 30, 50);
            itemButtons = new List<ItemButton>();
        }

        public void ClearMenu()
        {
            foreach (ItemButton itemButton in itemButtons)
                buttonsPool.Release(itemButton);
            itemButtons.Clear();
        }

        public ItemButton CreateButton(BaseItem item, Action<BaseItem> onHoverItem, Action onExitHoverItem, Action<ItemButton> onClick)
        {
            ItemButton newButton = buttonsPool.Get();
            newButton.transform.SetParent(inventoryContent);
            newButton.transform.localScale = Vector3.one;

            newButton.SetButton(newButton, item, onHoverItem, onExitHoverItem, onClick);
            itemButtons.Add(newButton);

            return newButton;
        }

        /// <summary>
        /// Directly deletes an ItemButton.
        /// </summary>
        public void DeleteButton(ItemButton itemButton)
        {
            itemButton.ClearButton();
            buttonsPool.Release(itemButton);
            itemButtons.Remove(itemButton);
        }

        /// <summary>
        /// Delete one of the itemButtons with given item.
        /// </summary>
        public void DeleteButton(BaseItem item)
        {
            foreach(ItemButton itemButton in itemButtons)
            {
                if (itemButton.Item != item)
                    continue;

                DeleteButton(itemButton);
                break;
            }
        }

    }
}
