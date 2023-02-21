using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasCustom.Actions
{
	[Category("Transform")]
	public class LerpScale : ActionTask<Transform>
	{
		public BBParameter<AnimationCurve> curve;
		public BBParameter<Vector3> targetScale;
		public BBParameter<float> time;

		private Vector3 initScale;

		private float t;

		protected override string info => $"Lerping Scale to {targetScale}";
		protected override void OnExecute()
		{
			initScale = agent.localScale;
			t = 0f;
		}

		protected override void OnUpdate()
		{
			t += Time.fixedDeltaTime / time.value;
			agent.localScale = Vector3.LerpUnclamped(initScale, targetScale.value, curve.value.Evaluate(t));
			if (t >= 1)
				EndAction(true);
		}
	}
}