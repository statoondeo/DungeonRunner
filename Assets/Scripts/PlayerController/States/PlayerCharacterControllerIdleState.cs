using UnityEngine;

public class PlayerCharacterControllerIdleState : BasePlayerCharacterControllerState
{
	protected bool Active;
	protected Position Movement;

	public PlayerCharacterControllerIdleState(IStateContainer container, Animator animator, bool active, Position movement)
		: base(container, animator)
	{
		Active = active;
		Movement = movement;
	}

	public override void Enter()
	{
		base.Enter();
		Animator.ResetTrigger(PlayerCharacterAnimationTriggers.Run);
		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Idle);
		Movement.Z = 0;
	}

	public override void Update()
	{
		base.Update();
		if (Active && Input.GetButton("Fire1"))
		{
			Container.SetState(Transitions[PlayerCharacterControllerStates.Running]);
		}
	}
}
