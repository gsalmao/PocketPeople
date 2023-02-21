using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	[Category("UI")]
	public class LerpTextColor : ActionTask<TextMeshProUGUI>
	{
		public BBParameter<AnimationCurve> curve;
		public BBParameter<Color> initColor;
		public BBParameter<Color> finalColor;
		public BBParameter<float> time;

		private float t;

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