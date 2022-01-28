using UnityEngine;
public class VerticalIdleState : BaseSubPlayerControllerStateItem
{
	protected CharacterController CharacterController;
	protected Position Movement;
	protected float Gravity;

	public VerticalIdleState(IStateContainer container, Animator animator, CharacterController characterController, Position movement, float gravity)
		: base(container, animator)
	{
		CharacterController = characterController;
		Movement = movement;
		Gravity = gravity;
	}

	public override void Enter()
	{
		base.Enter();
		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Run);
		Movement.Y = 0;
	}

	public override void Update()
	{
		base.Update();
		if (CharacterController.isGrounded)
		{
			float vMove = Input.GetAxis("Vertical");
			if (vMove > 0)
			{
				// Gestion du saut
				Container.SetState(Transitions[VerticalSubStates.Jump]);
			}
			else if (vMove < 0)
			{
				// Gestion de la glissade
				Container.SetState(Transitions[VerticalSubStates.Slide]);
			}
			else
			{
				Movement.Y = 0.0f;
			}
		}
		else
		{
			Movement.Y += Gravity * Time.deltaTime;
		}
	}
}
