 //Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Set snap drop zone valid object list policy for VRTK.")]

	public class  SetSnapDropZoneValidObjectList : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SnapDropZone))]    
		public FsmOwnerDefault gameObject;

		[UIHint(UIHint.Script)]
		public FsmObject validObjectListPolicy;

		public FsmBool everyFrame;

		VRTK.VRTK_SnapDropZone theScript;

		public override void Reset()
		{

			validObjectListPolicy = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_SnapDropZone>();

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

			theScript.validObjectListPolicy = (VRTK.VRTK_PolicyList)validObjectListPolicy.Value;
		}

	}
}