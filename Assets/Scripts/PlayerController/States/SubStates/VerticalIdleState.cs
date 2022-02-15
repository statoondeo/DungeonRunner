using UnityEngine;

public class VerticalIdleState : BasePlayerControllerState
{
	public VerticalIdleState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container, playerModel, playerView)
	{
	}

	public override void Enter()
	{
		base.Enter();
		PlayerView.Animator.SetTrigger(PlayerAnimationTriggers.Run);
		PlayerModel.NextMove.y = 0;
	}

	public override void Update()
	{
		base.Update();
		if (!PlayerView.CharacterController.isGrounded) // && !GameManager.Instance.CurrentScene.IsPaused)
		{
			PlayerModel.NextMove.y += PlayerModel.Gravity * Time.deltaTime;
		}
	}

	public override void OnMove(Vector2 move)
	{
		//if (!GameManager.Instance.CurrentScene.IsPaused) {
			base.OnMove(move);
			if (PlayerView.CharacterController.isGrounded)
			{
				if (move == Vector2.up)
				{
					// Gestion du saut
					Container.SetState(Transitions[VerticalSubStates.Jump]);
				}
				else if (move == Vector2.down)
				{
					// Gestion de la glissade
					Container.SetState(Transitions[VerticalSubStates.Slide]);
				}
			}
		//}
	}
}
