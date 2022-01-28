using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
	protected IStateContainer StateContainer;

	// Composants exterieurs utilisés
	[SerializeField] private Animator Animator;
	[SerializeField] private CharacterController CharacterController;
	[SerializeField] private GameplayController GameplayController;

	// Activation pour le gameplay
	[SerializeField] private bool Active;

	// Gravité artificielle
	[SerializeField] private float Gravity;

	// Mouvement vers l'avant
	[SerializeField] private float ForwardSpeed;

	// Gestion des mouvements verticaux
	[SerializeField] private float JumpHeight;
	[SerializeField] private float SlidingDuration;

	// Gestion des mouvements latéraux
	[SerializeField] private float HorizontalOffset;
	[SerializeField] private float LaneWidth;
	[SerializeField] private float LaningDuration;

	private void Awake()
	{
		// Contrôle des données utilisées
		Debug.Assert(Animator != null, gameObject.name + "/Animator not set");
		Debug.Assert(CharacterController != null, gameObject.name + "/CharacterController not set");
		Debug.Assert(ForwardSpeed != 0.0f, gameObject.name + "/ForwardSpeed not set");
		Debug.Assert(JumpHeight != 0.0f, gameObject.name + "/JumpHeight not set");
		Debug.Assert(SlidingDuration != 0.0f, gameObject.name + "/SlidingDuration not set");
		Debug.Assert(LaneWidth != 0.0f, gameObject.name + "/LaneWidth not set");
		Debug.Assert(LaningDuration != 0.0f, gameObject.name + "/LaningDuration not set");
	}

	private void Start()
	{
		// Création des états du PlayerController
		StateContainer = new StateContainer();
		Position momentum = new Position();
		IStateItem idleState = new PlayerCharacterControllerIdleState(StateContainer, Animator, Active, momentum);
		IStateItem runningState = new PlayerCharacterControllerRunningState(StateContainer, Animator, CharacterController, transform, momentum, ForwardSpeed, JumpHeight, SlidingDuration, LaneWidth, LaningDuration, Gravity, HorizontalOffset);
		IStateItem stumblingState = new PlayerCharacterControllerStumblingState(StateContainer, Animator, momentum);
		idleState.AddTransition(PlayerCharacterControllerStates.Running, runningState);
		idleState.AddTransition(PlayerCharacterControllerStates.Stumbling, stumblingState);
		runningState.AddTransition(PlayerCharacterControllerStates.Idle, idleState);
		stumblingState.AddTransition(PlayerCharacterControllerStates.Idle, idleState);
		StateContainer.SetState(idleState);
	}

	// Gestion des mouvements du joueur
	private void Update()
	{
		StateContainer.Update();
	}

	/// <summary>
	/// Gestion des contacts avec l'environnement
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		// Condition de fin de la partie
		if ((other.CompareTag(Tags.Obstacle) || other.CompareTag(Tags.Enemy)))
		{
			// Le joueur rencontre un obstacle, une alerte est affichée
			GameplayController?.SetCollisionAlert();
			Animator.SetTrigger(PlayerCharacterAnimationTriggers.Stumble);
			CharacterController.Move(-15 * Time.deltaTime * transform.forward);
		} 
		else if (other.CompareTag(Tags.Collectable))
		{
			// Le joueur ramasse un objet
			GameplayController.UpdateScore();
		}
	}
}
