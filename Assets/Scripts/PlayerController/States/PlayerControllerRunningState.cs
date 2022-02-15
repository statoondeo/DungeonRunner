using UnityEngine;

public class PlayerControllerRunningState : BasePlayerControllerState
{
	protected IStateContainer VerticalContainer;
	protected IStateContainer HorizontalContainer;
	protected GameEvent OnPlayerPositionChanged;


	public PlayerControllerRunningState(IStateContainer container, PlayerModel playerModel, PlayerView playerView, GameEvent onPlayerPositionChanged)
		: base(container, playerModel, playerView)
	{
		OnPlayerPositionChanged = onPlayerPositionChanged;

		VerticalContainer = new StateContainer();
		IStateItem idleState = new VerticalIdleState(VerticalContainer, playerModel, playerView);
		IStateItem jumpingState = new VerticalJumpingState(VerticalContainer, playerModel, playerView);
		IStateItem slidingState = new VerticalSlidingState(VerticalContainer, playerModel, playerView);
		idleState.AddTransition(VerticalSubStates.Jump, jumpingState);
		idleState.AddTransition(VerticalSubStates.Slide, slidingState);
		jumpingState.AddTransition(VerticalSubStates.Idle, idleState);
		slidingState.AddTransition(VerticalSubStates.Idle, idleState);
		VerticalContainer.SetState(idleState);

		HorizontalContainer = new StateContainer();
		idleState = new HorizontalIdleState(HorizontalContainer, playerModel, playerView);
		IStateItem leftState = new HorizontalSidedState(HorizontalContainer, playerModel, playerView, -1);
		IStateItem rightState = new HorizontalSidedState(HorizontalContainer, playerModel, playerView, 1);
		idleState.AddTransition(HorizontalSubStates.Left, leftState);
		idleState.AddTransition(HorizontalSubStates.Right, rightState);
		leftState.AddTransition(HorizontalSubStates.Idle, idleState);
		rightState.AddTransition(HorizontalSubStates.Idle, idleState);
		HorizontalContainer.SetState(idleState);
	}

	public override void Enter()
	{
		base.Enter();
		PlayerView.Animator.SetTrigger(PlayerAnimationTriggers.Run);
	}

	public override void Update()
	{
		PlayerModel.NextMove.z = PlayerModel.ForwardSpeed;
		base.Update();

		// Gestion des mouvements verticaux
		VerticalContainer.Update();

		// Gestion des mouvements horizontaux
		HorizontalContainer.Update();

		// Application du mouvement demandé
		PlayerView.CharacterController.Move((Vector3.up * PlayerModel.NextMove.y + Vector3.forward * PlayerModel.NextMove.z) * Time.deltaTime + Vector3.right * PlayerModel.NextMove.x);
		PlayerModel.Position = PlayerView.transform.position;

		// On indique aux observers le changement de position
		OnPlayerPositionChanged.Raise();
	}

	public override void OnMove(Vector2 move)
	{
		base.OnMove(move);

		// Gestion des mouvements verticaux
		VerticalContainer.OnMove(move);

		// Gestion des mouvements horizontaux
		HorizontalContainer.OnMove(move);
	}
}
