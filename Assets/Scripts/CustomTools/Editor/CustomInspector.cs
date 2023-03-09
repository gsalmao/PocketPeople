using System.Collections.Generic;
using UnityEditor;
using System.Reflection;
using Object = UnityEngine.Object;

namespace CustomTools.Editor
{
    [CustomEditor(typeof(Object), true), CanEditMultipleObjects]
    public class CustomInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            IEnumerable<MethodInfo> methods = target.GetType().GetMethods(flags);

            foreach (MethodInfo method in methods)
            {
                var buttonAttribute = method.GetCustomAttribute<ButtonAttribute>();
                if (buttonAttribute == null)
                    continue;

                ButtonAttributeDrawer.DrawButton(target, method, buttonAttribute);
            }
        }
    }
}