using System.Collections.Generic;
using UnityEditor;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace CustomTools.Editor
{
    /// <summary>
    /// Custom Inspector to draw extra elements.
    /// </summary>
    [CustomEditor(typeof(Object), true), CanEditMultipleObjects]
    public class CustomInspector : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);
            
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            IEnumerable<MethodInfo> methods = target.GetType().GetMethods(flags);
            
            foreach (MethodInfo method in methods)
            {
                var buttonAttribute = method.GetCustomAttribute<ButtonAttribute>();
                if (buttonAttribute == null)
                    continue;
            
                ButtonsDrawer.DrawButton(root, target, method, buttonAttribute);
            }

            return root;
        }
    }
}