using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

namespace PocketPeople.Items
{
    /// <summary>
    /// Item Menu's object pooling system.
    /// </summary>
    public class ItemMenu : MonoBehaviour
    {
        [SerializeField, FoldoutGroup("References")] private Transform inventoryContent;

        private ObjectPool<Transform> buttonsPool;

        public void InitItemMenu(Transform buttonToInstantiate)
        {
            buttonsPool = new ObjectPool<Transform>(
            () => Instantiate(buttonToInstantiate),
            button => button.gameObject.SetActive(true),
            button => button.gameObject.SetActive(false),
            button => Destroy(button), false, 30, 50);
        }

        public Transform CreateButton()
        {
            Transform newButton = buttonsPool.Get();
            newButton.SetParent(inventoryContent);
            newButton.localScale = Vector3.one;
            return newButton;
        }
    }
}
