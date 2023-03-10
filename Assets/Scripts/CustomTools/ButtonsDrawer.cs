using System.Reflection;
using UnityEngine.UIElements;

namespace CustomTools
{
    /// <summary>
    /// Responsible for drawing button attributes in the inspector.
    /// </summary>
    public static class ButtonsDrawer
    {
        private static VisualElement _root;
        private static object _methodOwner;
        private static MethodInfo _method;
        private static string _buttonName;
        private static object[] _parameters;
        private static ButtonBehaviour _buttonBehaviour;
        private static Button _button;
        public static void DrawButton(VisualElement root, object methodOwner, MethodInfo method, ButtonAttribute buttonAttribute)
        {
            _root = root;
            _methodOwner = methodOwner;
            _method = method;
            _buttonName = string.IsNullOrEmpty(buttonAttribute.Name) ? method.Name : buttonAttribute.Name;
            _parameters = method.GetParameters();
            _buttonBehaviour = new ButtonBehaviour(_methodOwner, _method, _parameters); //TODO: try to eliminate this class and use lambda expression instead
            _button = new Button(_buttonBehaviour.ClickButton) { text = _buttonName };
            
            if (_parameters.Length == 0)
                _root.Add(_button);
            else
                DrawButtonWithAttributes();
        }

        private static void DrawButtonWithAttributes()  //TODO: Draw parameters as propertyFields, get parameters as objects
        {
            Foldout foldout = new Foldout { text = _buttonName };
            _root.Add(foldout);
            foldout.Add(_button);
        }
    }
}
