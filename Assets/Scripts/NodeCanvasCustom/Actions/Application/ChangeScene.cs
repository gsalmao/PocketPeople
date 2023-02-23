using NodeCanvas.Framework;
using ParadoxNotion.Design;
using PocketPeople.ApplicationManager;

namespace NodeCanvasCustom.Actions
{
	[Category("Application")]
	public class ChangeScene : ActionTask
	{
		public BBParameter<string> nextScene;

		protected override string info => $"Change scene to {nextScene}.";

        protected override void OnExecute() => SceneLoader.ChangeScene(nextScene.value, OnEndAction);
		private void OnEndAction() => EndAction(true);

	}
}