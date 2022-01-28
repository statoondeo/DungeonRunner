using UnityEngine;

public class VerticalSlidingState : BaseSubPlayerControllerStateItem
{
	protected float Duration;
	protected float Ttl;
	protected float Gravity;
	protected Position Movement;

	public VerticalSlidingState(IStateContainer container, Animator animator, Position movement, float duration, float gravity)
		: base(container, animator)
	{
		Movement = movement;
		Duration = duration;
		Gravity = gravity;
	}

	public override void Enter()
	{
		base.Enter();
		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Slide);
		Ttl = 0;
	}

	public override void Update()
	{
		base.Update();
		Ttl += Time.deltaTime;
		Movement.Y += Gravity * Time.deltaTime;
		if (Ttl > Duration)
		{
			Container.SetState(Transitions[VerticalSubStates.Idle]);
		}
	}
}
