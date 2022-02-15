using UnityEngine;

public class VerticalJumpingState : BasePlayerControllerState
{
	public VerticalJumpingState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container, playerModel, playerView)
	{
	}

	public override void Enter()
	{
		base.Enter();
		PlayerView.Animator.SetTrigger(PlayerAnimationTriggers.Jump);
		PlayerModel.NextMove.y = PlayerModel.JumpHeight;
	}

	public override void Update()
	{
		base.Update();
		PlayerModel.NextMove.y += PlayerModel.Gravity * Time.deltaTime;
		if (PlayerView.CharacterController.isGrounded && (PlayerModel.NextMove.y < 0))
		{
			Container.SetState(Transitions[VerticalSubStates.Idle]);
		}
	}
}
