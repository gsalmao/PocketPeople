using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Items
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField, FoldoutGroup("References")] List<ItemButton> buttons;
        [SerializeField] private List<BaseItem> items;
        [SerializeField] private Equipment equipment;
        [SerializeField] private GameObject interactionSight;
        private void Awake()
        {
            Debug.Log("Inventory Awake");
            equipment.InitClothes();
        }

        private int windowsAmount = 0;
        private int currentWindow = 0;
        private void OnEnable()
        {
            interactionSight.SetActive(false);
            windowsAmount = items.Count % buttons.Count;

            for(int i = 0; i < buttons.Count - 1; i++)
            {
                if (i < items.Count)
                    buttons[i].SetButton(items[i + currentWindow * buttons.Count]);
                else
                    buttons[i].ClearButton();
            }
        }


    }
}
