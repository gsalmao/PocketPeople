using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvasCustom.Actions
{
	[Category("Application")]
	public class QuitGame : ActionTask
	{
		protected override void OnExecute() => Application.Quit();
	}
}