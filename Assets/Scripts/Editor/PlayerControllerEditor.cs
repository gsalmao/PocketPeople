using PocketPeople.Player;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace PocketPeople.Editor
{
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : UnityEditor.Editor
    {
        public VisualTreeAsset playerController_UXML;
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();
            playerController_UXML.CloneTree(root);
            return root;
        }
    }
}