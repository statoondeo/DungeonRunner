using UnityEngine;

public class HorizontalIdleState : BaseSubPlayerControllerStateItem
{
	protected Transform Transform;
	protected Position Movement;
	protected float HorizontalOffset;

	public HorizontalIdleState(IStateContainer container, Animator animator, Transform transform, Position movement, float horizontalOffset)
		: base(container, animator)
	{
		Transform = transform;
		Movement = movement;
		HorizontalOffset = horizontalOffset;
	}

	public override void Enter()
	{
		base.Enter();
		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Run);
		Movement.X = 0;
	}

	public override void Update()
	{
		base.Update();

		float hMove = Input.GetAxis("Horizontal");
		// On vérifie que l'on ne sort pas des limites avant d'effectuer les mouvements
		if ((hMove > 0) && (Transform.position.x <= HorizontalOffset))
		{
			// Déplacement à droite
			Container.SetState(Transitions[HorizontalSubStates.Right]);
		}
		else if ((hMove < 0) && (Transform.position.x >= HorizontalOffset))
		{
			// Déplacement à gauche
			Container.SetState(Transitions[HorizontalSubStates.Left]);
		}
	}
}
