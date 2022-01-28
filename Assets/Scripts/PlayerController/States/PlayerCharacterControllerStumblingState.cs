using UnityEngine;

public class PlayerCharacterControllerStumblingState : BasePlayerCharacterControllerState
{
	protected Position Movement;

	public PlayerCharacterControllerStumblingState(IStateContainer container, Animator animator, Position movement)
		: base(container, animator)
	{
		Movement = movement;
	}

	public override void Enter()
	{
		base.Enter();
		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Stumble);
		Movement.Z = 0;
	}
}
