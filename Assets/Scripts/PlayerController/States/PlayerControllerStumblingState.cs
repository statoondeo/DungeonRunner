public class PlayerControllerStumblingState : BasePlayerControllerState
{
	public PlayerControllerStumblingState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container, playerModel, playerView)
	{
	}

	public override void Enter()
	{
		base.Enter();
		PlayerView.Animator.SetTrigger(PlayerAnimationTriggers.Stumble);
		PlayerModel.NextMove.z = 0;
	}
}
