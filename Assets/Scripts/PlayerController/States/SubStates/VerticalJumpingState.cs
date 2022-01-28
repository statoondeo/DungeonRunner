using UnityEngine;

public class VerticalJumpingState : BaseSubPlayerControllerStateItem
{
	protected CharacterController CharacterController;
	protected float JumpHeight;
	protected float Gravity;
	protected Position Movement;

	public VerticalJumpingState(IStateContainer container, Animator animator, CharacterController characterController, Position movement, float jumpHeight, float gravity)
		: base(container, animator)
	{
		CharacterController = characterController;
		Movement = movement;
		JumpHeight = jumpHeight;
		Gravity = gravity;
	}

	public override void Enter()
	{
		base.Enter();
		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Jump);
		Movement.Y = JumpHeight;
	}

	public override void Update()
	{
		base.Update();
		Movement.Y += Gravity * Time.deltaTime;
		if (CharacterController.isGrounded)
		{
			Container.SetState(Transitions[VerticalSubStates.Idle]);
		}
	}
}
