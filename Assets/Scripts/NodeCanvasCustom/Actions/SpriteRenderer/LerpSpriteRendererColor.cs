using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

	[Category("SpriteRenderer")]
	public class LerpSpriteRendererColor : ActionTask<SpriteRenderer>
	{
		public BBParameter<AnimationCurve> curve;
		public BBParameter<Color> initColor;
		public BBParameter<Color> finalColor;
		public BBParameter<float> time;

		private float t;

		protected override string info => $"Lerping SpriteRenderer Color to {finalColor}";

		protected override void OnExecute() => t = 0f;

		protected override void OnUpdate()
		{
			t += Time.fixedDeltaTime / time.value;
			agent.color = Color.Lerp(initColor.value, finalColor.value, curve.value.Evaluate(t));
			if (t >= 1)
				EndAction(true);
		}
	}
}