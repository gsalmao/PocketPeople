using System.Reflection;

namespace CustomTools
{
    /// <summary>
    /// This class holds the behaviour of the button.
    /// </summary>
    internal class ButtonBehaviour
    {
        private readonly object _methodOwner;
        private readonly MethodInfo _method;
        private readonly object[] _parameters;
        
        public ButtonBehaviour(object methodOwner, MethodInfo method, params object[] parameters)
        {
            _methodOwner = methodOwner;
            _method = method;
            _parameters = parameters;
        }

        public void ClickButton() => _method.Invoke(_methodOwner, _parameters);
    }
}
