using UnityEngine;

public class HorizontalSidedState : BasePlayerControllerState
{
	protected float Ttl;
	protected float FinalPosition;
	protected float NewPosition;
	protected float OldPosition;
	protected int Direction;

	public HorizontalSidedState(IStateContainer container, PlayerModel playerModel, PlayerView playerView, int direction)
		: base(container, playerModel, playerView)
	{
		Direction = direction;
	}

	public override void Enter()
	{
		base.Enter();
		Ttl = 0;
		FinalPosition = PlayerModel.Position.x + PlayerModel.LaneWidth * Direction;
		NewPosition = 0;
	}

	public override void Update()
	{
		base.Update();
		Ttl += Time.deltaTime;
		if (Ttl > PlayerModel.LaningDuration)
		{
			Container.SetState(Transitions[HorizontalSubStates.Idle]);
		}
		else
		{
			OldPosition = NewPosition;
			NewPosition = Ttl / PlayerModel.LaningDuration * PlayerModel.LaneWidth * Direction;
			PlayerModel.NextMove.x = NewPosition - OldPosition;
		}
	}

	public override void Exit()
	{
		base.Exit();
		PlayerModel.NextMove.x = FinalPosition - PlayerModel.Position.x;
	}
}
