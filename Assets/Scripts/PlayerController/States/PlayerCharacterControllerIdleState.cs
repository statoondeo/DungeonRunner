//using UnityEngine;

//public class PlayerCharacterControllerIdleState : BasePlayerCharacterControllerState
//{
//	protected bool Active;
//	protected Position Movement;
//	protected bool TransitionRequired;

//	public PlayerCharacterControllerIdleState(IStateContainer container, Animator animator, bool active, Position movement)
//		: base(container, animator)
//	{
//		Active = active;
//		Movement = movement;
//		TransitionRequired = false;
//	}

//	public override void Enter()
//	{
//		base.Enter();
//		Animator.ResetTrigger(PlayerCharacterAnimationTriggers.Run);
//		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Idle);
//		Movement.Z = 0;
//	}

//	public override void OnMove(InputController inputController)
//	{
//		if (!GameManager.Instance.CurrentScene.IsPaused)
//		{
//			base.OnMove(inputController);
//			Container.SetState(Transitions[PlayerCharacterControllerStates.Running]);
//		}
//	}
//}
