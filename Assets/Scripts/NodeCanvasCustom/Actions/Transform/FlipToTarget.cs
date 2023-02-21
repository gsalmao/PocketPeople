using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasCustom.Actions
{
    [Category("Transform")]
    [Description("Change the Y rotation based on target.")]
    public class FlipToTarget : ActionTask<Transform> 
    {
        public BBParameter<Transform> target;

        protected override string info => $"Flip To {target}";

        protected override void OnExecute()
        {
            float rotation = target.value.position.x < agent.position.x ? 180f : 0f;
            agent.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
            EndAction(true);
        }
    }
}