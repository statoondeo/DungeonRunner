//using UnityEngine;

//public class PlayerCharacterControllerRunningState : BasePlayerCharacterControllerState
//{
//	protected CharacterController CharacterController;
//	protected IStateContainer VerticalContainer;
//	protected IStateContainer HorizontalContainer;
//	public float ForwardSpeed;
//	protected Position Movement;

//	public PlayerCharacterControllerRunningState(IStateContainer container, Animator animator, CharacterController characterController, Transform transform, Position movement, float forwardSpeed, float jumpHeight, float slidingDuration, float laneWidth, float laningDuration, float gravity)
//		: base(container, animator)
//	{
//		CharacterController = characterController;
//		ForwardSpeed = forwardSpeed;
//		Movement = movement;

//		VerticalContainer = new StateContainer();
//		IStateItem idleState = new VerticalIdleState(VerticalContainer, Animator, CharacterController, Movement, gravity);
//		IStateItem jumpingState = new VerticalJumpingState(VerticalContainer, Animator, CharacterController, Movement, jumpHeight, gravity);
//		IStateItem slidingState = new VerticalSlidingState(VerticalContainer, Animator, CharacterController, Movement, slidingDuration, gravity);
//		idleState.AddTransition(VerticalSubStates.Jump, jumpingState);
//		idleState.AddTransition(VerticalSubStates.Slide, slidingState);
//		jumpingState.AddTransition(VerticalSubStates.Idle, idleState);
//		slidingState.AddTransition(VerticalSubStates.Idle, idleState);
//		VerticalContainer.SetState(idleState);

//		HorizontalContainer = new StateContainer();
//		idleState = new HorizontalIdleState(HorizontalContainer, Animator, transform, Movement);
//		IStateItem leftState = new HorizontalSidedState(HorizontalContainer, transform, Movement, laneWidth, -1, laningDuration);
//		IStateItem rightState = new HorizontalSidedState(HorizontalContainer, transform, Movement, laneWidth, 1, laningDuration);
//		idleState.AddTransition(HorizontalSubStates.Left, leftState);
//		idleState.AddTransition(HorizontalSubStates.Right, rightState);
//		leftState.AddTransition(HorizontalSubStates.Idle, idleState);
//		rightState.AddTransition(HorizontalSubStates.Idle, idleState);
//		HorizontalContainer.SetState(idleState);
//	}

//	public override void Enter()
//	{
//		base.Enter();
//		Animator.SetTrigger(PlayerCharacterAnimationTriggers.Run);
//	}

//	public override void Update()
//	{
//		Movement.Z = ForwardSpeed;
//		base.Update();

//		// Gestion des mouvements verticaux
//		VerticalContainer.Update();

//		// Gestion des mouvements horizontaux
//		HorizontalContainer.Update();

//		// Application du mouvement demandé
//		CharacterController.Move((Vector3.up * Movement.Y + Vector3.forward * Movement.Z) * Time.deltaTime + Vector3.right * Movement.X);
//	}

//	public override void OnMove(InputController inputController)
//	{
//		base.OnMove(inputController);

//		// Gestion des mouvements verticaux
//		VerticalContainer.OnMove(inputController);

//		// Gestion des mouvements horizontaux
//		HorizontalContainer.OnMove(inputController);
//	}
//}
