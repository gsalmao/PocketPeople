using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using UnityEngine;
using UnityEngine.UIElements;

namespace CustomTools.Editor
{
    public static class ButtonAttributeDrawer
    {
        public static void DrawButton(Object methodOwner, MethodInfo method, ButtonAttribute buttonAttribute)
        {
            string buttonName = buttonAttribute.Name != null ? buttonAttribute.Name : method.Name;
            
            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            if (parameters.Count() > 0)
                return;
            
            if (GUILayout.Button(buttonName))    
                method.Invoke(methodOwner, null);
        }
    }
}
