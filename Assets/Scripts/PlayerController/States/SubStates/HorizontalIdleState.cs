using UnityEngine;

public class HorizontalIdleState : BasePlayerControllerState
{
	protected int Lane;

	public HorizontalIdleState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container, playerModel, playerView)
	{
		Lane = 0;
	}

	public override void Enter()
	{
		base.Enter();
		PlayerView.Animator.SetTrigger(PlayerAnimationTriggers.Run);
		PlayerModel.NextMove.x = 0;
	}

	public override void OnMove(Vector2 move)
	{
		//if (!GameManager.Instance.CurrentScene.IsPaused) {
			base.OnMove(move);
			// On vérifie que l'on ne sort pas des limites avant d'effectuer les mouvements
			if ((move == Vector2.right) && (Lane <= 0))
			{
				// Déplacement à droite
				Lane++;
				Container.SetState(Transitions[HorizontalSubStates.Right]);
			}
			else if ((move == Vector2.left) && (Lane >= 0))
			{
				// Déplacement à gauche
				Lane--;
				Container.SetState(Transitions[HorizontalSubStates.Left]);
			}
		//}
	}
}
