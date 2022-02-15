using UnityEngine;

public class VerticalSlidingState : BasePlayerControllerState
{
	protected static readonly float SlidingHeightRatio = 0.5f;

	protected float CharacterHeight;
	protected Vector3 CenterHeight;
	protected float Ttl;

	public VerticalSlidingState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container, playerModel, playerView)
	{
	}

	public override void Enter()
	{
		base.Enter();
		CharacterHeight = PlayerView.CharacterController.height;
		CenterHeight = PlayerView.CharacterController.center;
		PlayerView.CharacterController.height = CharacterHeight * SlidingHeightRatio;
		PlayerView.CharacterController.center = new Vector3(PlayerView.CharacterController.center.x, PlayerView.CharacterController.center.y * SlidingHeightRatio, PlayerView.CharacterController.center.z);
		PlayerView.Animator.SetTrigger(PlayerAnimationTriggers.Slide);
		Ttl = 0.0f;
	}

	public override void Update()
	{
		base.Update();
		Ttl += Time.deltaTime;
		PlayerModel.NextMove.y += PlayerModel.Gravity * Time.deltaTime;
		if (Ttl > PlayerModel.SlidingDuration)
		{
			Container.SetState(Transitions[VerticalSubStates.Idle]);
		}
	}

	public override void Exit()
	{
		base.Exit();
		PlayerView.CharacterController.height = CharacterHeight;
		PlayerView.CharacterController.center = CenterHeight;
	}
}
