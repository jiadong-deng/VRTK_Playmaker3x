// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Starts auto grab of selected object in the scene.")]

	public class  AutoGrabObject : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_InteractableObject))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Starts grab. Set to false to drop object.")]
		public FsmBool grab;

		VRTK_InteractGrab interactableObject;

		public override void Reset()
		{

			grab = true;
			gameObject = null;
			
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			interactableObject = go.GetComponent<VRTK_InteractGrab>();

			if (grab.Value)
			{
				autoGrab();
				Finish();
			}
			
			else 
			{
				drop();
				Finish();
			}

		}


		void autoGrab()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			interactableObject.AttemptGrab();

		}
		
		void drop()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			interactableObject.ForceRelease();
			
		}

	}
}