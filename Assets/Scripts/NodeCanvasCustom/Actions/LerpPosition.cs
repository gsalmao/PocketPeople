using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasCustom.Actions
{
	[Category("Transform")]
	public class LerpPosition : ActionTask<Transform>
	{
		public BBParameter<AnimationCurve> curveX;
		public BBParameter<AnimationCurve> curveY;
		public BBParameter<Transform> target;

		public BBParameter<float> time;

		private Vector2 initPosition;
		private Vector2 finalPosition;
		private Vector2 currentPosition;
		private float t;
		protected override string info => $"Lerping To {target}";

		protected override void OnExecute()
		{
			initPosition = agent.position;
			finalPosition = target.value.position;
			currentPosition = initPosition;
			t = 0f;
		}

		protected override void OnUpdate()
		{
			t += Time.fixedDeltaTime / time.value;

			currentPosition.x = Mathf.LerpUnclamped(initPosition.x, finalPosition.x, curveX.value.Evaluate(t));
			currentPosition.y = Mathf.LerpUnclamped(initPosition.y, finalPosition.y, curveY.value.Evaluate(t));

			agent.position = currentPosition;

			if (t >= 1)
				EndAction(true);
		}
	}
}