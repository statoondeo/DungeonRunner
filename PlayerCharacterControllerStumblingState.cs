using UnityEngine;

//public class PlayerCharacterControllerStumblingState : BasePlayerCharacterControllerState
//{
//	protected Position Movement;

//	public PlayerCharacterControllerStumblingState(IStateContainer container, Animator animator, Position movement)
//		: base(container, animator)
//	{
//		Movement = movement;
//	}

//	public override void Enter()
//	{
//		base.Enter();
//		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Stumble);
//		Movement.Z = 0;
//	}
//}
public class PlayerControllerStumblingState : BasePlayerControllerState
{
	public PlayerControllerStumblingState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container, playerModel, playerView)
	{
	}

	public override void Enter()
	{
		base.Enter();
		PlayerView.Animator.SetTrigger(PlayerCharacterAnimationTriggers.Stumble);
		PlayerModel.NextMove.z = 0;
	}
}
