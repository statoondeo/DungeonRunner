using UnityEngine;

public class HorizontalSidedState : BaseSubPlayerControllerStateItem
{
	protected Transform Transform;
	protected float Ttl;
	protected float FinalPosition;
	protected float NewPosition;
	protected float OldPosition;
	protected float LaneWidth;
	protected float Duration;
	protected int Direction;
	protected Position Movement;
	protected bool ReturnToIdle;

	public HorizontalSidedState(IStateContainer container, Transform transform, Position movement, float laneWidth, int direction, float duration)
		: base(container, null)
	{
		Transform = transform;
		Movement = movement;
		LaneWidth = laneWidth;
		Direction = direction;
		Duration = duration;
	}

	public override void Enter()
	{
		base.Enter();
		ReturnToIdle = false;
		Ttl = 0;
		FinalPosition = Transform.position.x + LaneWidth * Direction;
		NewPosition = 0;
	}

	public override void Update()
	{
		base.Update();
		if (ReturnToIdle)
		{
			Container.SetState(Transitions[HorizontalSubStates.Idle]);
		}
		else
		{
			Ttl += Time.deltaTime;
			if (Ttl > Duration)
			{
				Movement.X = FinalPosition - Transform.position.x;
				ReturnToIdle = true;
			}
			else
			{
				OldPosition = NewPosition;
				NewPosition = Ttl / Duration * LaneWidth * Direction;
				Movement.X = NewPosition - OldPosition;
			}
		}
	}
}
