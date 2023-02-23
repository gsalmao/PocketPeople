using NodeCanvas.Framework;
using ParadoxNotion.Design;
using PocketPeople.Player;
using UnityEngine;

namespace NodeCanvasCustom.Actions{

	[Category("Player")]
	public class GetPlayerTransform : ActionTask
	{
		public BBParameter<Transform> playerTransform;
		protected override void OnExecute()
		{
			playerTransform.value = PlayerController.PlayerBody;
			EndAction(true);
		}
	}
}