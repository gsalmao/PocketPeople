using FMODUnity;
using System;
using System.Collections.Generic;
using PocketPeople.Items.Data;

namespace PocketPeople.Items
{
    /// <summary>
    /// Process the player's inventory.
    /// </summary>
    public static class Inventory
    {
        public static event Action OnChangeMoney = delegate { };
        public static event Action<RuntimeItem> OnReceiveItem = delegate { };
        public static event Action<RuntimeItem> OnTakeItem = delegate { };

        public static List<RuntimeItem> Items { get; private set; }
        public static Equipment PlayerEquipment { get; private set; }
        public static int Money { get; private set; }

        private static EventReference useItemSound;
        private static bool initialized = false;


        public static void Init(List<ItemData> initItems, int newMoney, List<EquipmentData> initEquipments, EventReference itemSound)
        {
            if (initialized)
                return;

            useItemSound = itemSound;

            //Inventory
            Items = new List<RuntimeItem>();

            foreach (ItemData item in initItems)
                Items.Add(new RuntimeItem(item));

            //Equipment
            List<RuntimeItem> initEquipmentsRuntime = new List<RuntimeItem>();

            foreach (EquipmentData initEquip in initEquipments)
                initEquipmentsRuntime.Add(new RuntimeItem(initEquip));

            PlayerEquipment = new Equipment(initEquipmentsRuntime);

            //Money
            Money = newMoney;

            initialized = true;
        }


        #region Item Methods
        public static void ReceiveItem(RuntimeItem item)
        {
            Items.Add(item);
            OnReceiveItem(item);
        }

        public static void TakeItem(RuntimeItem item)
        {
            Items.Remove(item);
            OnTakeItem(item);
        }

        public static void UseItem(RuntimeItem item)
        {
            ItemData checkedItem = item.ItemData;

            if (checkedItem is ConsummableData)
            {
                ConsummableData consummable = checkedItem as ConsummableData;
                RuntimeManager.PlayOneShot(useItemSound);
                consummable.UseEffect.Activate();
                if (consummable.OneTime)
                    TakeItem(item);
                return;
            }

            if (checkedItem is EquipmentData)
            {
                RuntimeManager.PlayOneShot(useItemSound);
                (checkedItem as EquipmentData).EquipEffect.Activate();
                PlayerEquipment.EquipItem(item);
                return;
            }
        }
        #endregion

        #region Money Methods
        public static void ReceiveMoney(int amount)
        {
            Money += amount;
            OnChangeMoney();
        }

        public static void TakeMoney(int amount)
        {
            if (amount > Money)
                Money = 0;
            else
                Money -= amount;
            OnChangeMoney();
        }
        #endregion

    }
}
