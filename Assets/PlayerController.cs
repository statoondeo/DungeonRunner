using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Evènements émis
	[SerializeField] private GameEvent OnPlayerPositionChanged;
	[SerializeField] private GameEvent OnPlayerDead;

	// Modèle de données
	[SerializeField] private PlayerModel PlayerModel;

	// Vue manipulée
	[SerializeField] private PlayerView PlayerView;

	// Etats internes
	private IStateContainer StateContainer;
	private IStateItem StumbleState;

	#region Gestion des messages Unity

	private void Awake()
	{
		// Contrôles des références
		if (null == OnPlayerPositionChanged) throw new System.ArgumentNullException("OnPlayerPositionChanged reference is missing!");
		if (null == OnPlayerDead) throw new System.ArgumentNullException("OnPlayerDead reference is missing!");
		if (null == PlayerModel) throw new System.ArgumentNullException("PlayerModel reference is missing!");
		if (null == PlayerView) throw new System.ArgumentNullException("PlayerView reference is missing!");
	}

	private void Start()
	{
		// Création des états du PlayerController
		StateContainer = new StateContainer();
		IStateItem idleState = new PlayerControllerIdleState(StateContainer, PlayerModel, PlayerView);
		IStateItem runningState = new PlayerControllerRunningState(StateContainer, PlayerModel, PlayerView, OnPlayerPositionChanged);
		StumbleState = new PlayerControllerStumblingState(StateContainer, PlayerModel, PlayerView);
		idleState.AddTransition(PlayerControllerStates.Running, runningState);
		idleState.AddTransition(PlayerControllerStates.Stumbling, StumbleState);
		runningState.AddTransition(PlayerControllerStates.Idle, idleState);
		StumbleState.AddTransition(PlayerControllerStates.Idle, idleState);
		StateContainer.SetState(idleState);

		PlayerModel.Position = PlayerView.transform.position;
		OnPlayerPositionChanged.Raise();
	}

	// Gestion des mouvements du joueur
	private void Update()
	{
		StateContainer.Update();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(Tags.Obstacle) || other.CompareTag(Tags.Enemy))
		{
			StateContainer.SetState(StumbleState);
			PlayerModel.Active = false;
			OnPlayerDead.Raise();
		}
	}

	#endregion

	#region Gestion du PlayerController

	public void OnInputSwiped(InputModel inputModel)
	{
		if (PlayerModel.Active)
		{
			StateContainer.OnMove(inputModel.Swipe);
		}
	}

	public void OnSpeedChangedCallBack(PlayerModel playerModel)
	{
		PlayerView.Animator.SetFloat("RunSpeed", PlayerModel.ForwardSpeed / PlayerModel.InitialForwardSpeed);
	}

	#endregion
}
