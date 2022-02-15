using UnityEngine;

public class PlayerControllerIdleState : BasePlayerControllerState
{
	public PlayerControllerIdleState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container, playerModel, playerView)
	{
	}

	public override void Enter()
	{
		base.Enter();
		PlayerView.Animator.ResetTrigger(PlayerAnimationTriggers.Run);
		PlayerView.Animator.SetTrigger(PlayerAnimationTriggers.Idle);
		PlayerModel.NextMove.z = 0;
	}

	public override void OnMove(Vector2 move)
	{
		base.OnMove(move);
		Container.SetState(Transitions[PlayerControllerStates.Running]);
	}
}
