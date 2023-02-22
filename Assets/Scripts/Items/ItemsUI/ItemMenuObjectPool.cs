using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

namespace PocketPeople.Items.UI
{
    /// <summary>
    /// Item Menu's object pooling system.
    /// </summary>
    public class ItemMenuObjectPool : MonoBehaviour
    {
        [SerializeField, FoldoutGroup("References")] private Transform inventoryContent;
        [SerializeField, FoldoutGroup("References")] private ItemButton itemButtonPrefab;
        private ObjectPool<ItemButton> buttonsPool;

        public void InitItemMenu()
        {
            buttonsPool = new ObjectPool<ItemButton>(
            () => Instantiate(itemButtonPrefab),
            button => button.gameObject.SetActive(true),
            button => button.gameObject.SetActive(false),
            button => Destroy(button), false, 30, 50);
        }

        public ItemButton CreateButton()
        {
            ItemButton newButton = buttonsPool.Get();
            newButton.transform.SetParent(inventoryContent);
            newButton.transform.localScale = Vector3.one;
            return newButton;
        }
    }
}
