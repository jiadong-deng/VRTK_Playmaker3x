// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Check if any button is down on the controllers.")]

	public class  GetAnyButtonDown : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("True if any button on the controller is pressed")]
		public FsmBool anyButtonPressed;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerEvents theScript;

		public override void Reset()
		{

			anyButtonPressed = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_ControllerEvents>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			anyButtonPressed.Value = theScript.AnyButtonPressed();

		}

	}
}