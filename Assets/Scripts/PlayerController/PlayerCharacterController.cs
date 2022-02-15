//using UnityEngine;

//public class PlayerCharacterController : MonoBehaviour
//{
//	protected IStateContainer StateContainer;

//	// Composants exterieurs utilisés
//	[SerializeField] private Animator Animator;
//	[SerializeField] private CharacterController CharacterController;
//	[SerializeField] private GameplayController GameplayController;
//	[SerializeField] private InputController InputController;

//	// Activation pour le gameplay
//	[SerializeField] private bool Active;

//	// Gravité artificielle
//	[SerializeField] private float Gravity;

//	// Mouvement vers l'avant
//	[SerializeField] private float ForwardSpeed;

//	// Gestion des mouvements verticaux
//	[SerializeField] private float JumpHeight;
//	[SerializeField] private float SlidingDuration;

//	// Gestion des mouvements latéraux
//	[SerializeField] private float LaneWidth;
//	[SerializeField] private float LaningDuration;

//	private float InitialForwardSpeed;
//	private IStateItem StumbleState;
//	private PlayerCharacterControllerRunningState RunningState;

//	private void Awake()
//	{
//		// Contrôle des données utilisées
//		Debug.Assert(Animator != null, gameObject.name + "/Animator not set");
//		Debug.Assert(CharacterController != null, gameObject.name + "/CharacterController not set");
//		Debug.Assert(GameplayController != null, gameObject.name + "/GameplayController not set");
//		Debug.Assert(InputController != null, gameObject.name + "/InputController not set");
//		Debug.Assert(ForwardSpeed != 0.0f, gameObject.name + "/ForwardSpeed not set");
//		Debug.Assert(JumpHeight != 0.0f, gameObject.name + "/JumpHeight not set");
//		Debug.Assert(SlidingDuration != 0.0f, gameObject.name + "/SlidingDuration not set");
//		Debug.Assert(LaneWidth != 0.0f, gameObject.name + "/LaneWidth not set");
//		Debug.Assert(LaningDuration != 0.0f, gameObject.name + "/LaningDuration not set");
//		InitialForwardSpeed = ForwardSpeed;
//	}

//	private void Start()
//	{
//		// Création des états du PlayerController
//		StateContainer = new StateContainer();
//		Position momentum = new Position();
//		IStateItem idleState = new PlayerCharacterControllerIdleState(StateContainer, Animator, Active, momentum);
//		RunningState = new PlayerCharacterControllerRunningState(StateContainer, Animator, CharacterController, transform, momentum, ForwardSpeed, JumpHeight, SlidingDuration, LaneWidth, LaningDuration, Gravity);
//		StumbleState = new PlayerCharacterControllerStumblingState(StateContainer, Animator, momentum);
//		idleState.AddTransition(PlayerCharacterControllerStates.Running, RunningState);
//		idleState.AddTransition(PlayerCharacterControllerStates.Stumbling, StumbleState);
//		RunningState.AddTransition(PlayerCharacterControllerStates.Idle, idleState);
//		StumbleState.AddTransition(PlayerCharacterControllerStates.Idle, idleState);
//		StateContainer.SetState(idleState);
//	}

//	// Gestion des mouvements du joueur
//	private void Update()
//	{
//		StateContainer.Update();
//		if (Active && (InputController.Swipe != Vector2.zero))
//		{
//			OnMove(InputController);
//		}
//	}

//	private void SetCollision()
//	{
//		GameplayController.SetCollisionAlert();
//	}

//	/// <summary>
//	/// Connexion avec le PlayerInput/InputManager
//	/// </summary>
//	public void OnMove(InputController inputController)
//	{
//		StateContainer.OnMove(inputController);
//	}

//	/// <summary>
//	/// Récupération de la vitesse
//	/// </summary>
//	/// <returns></returns>
//	public float GetForwardSpeed() => ForwardSpeed;

//	/// <summary>
//	/// Mise à jour de la vitesse de déplacement vers l'avant (prise de bonus par exemple)
//	/// </summary>
//	/// <param name="multiplier"></param>
//	public void UpdateSpeed(float multiplier)
//	{
//		ForwardSpeed *= multiplier;
//		RunningState.ForwardSpeed = ForwardSpeed;
//		Animator.SetFloat("RunSpeed", ForwardSpeed / InitialForwardSpeed);
//	}

//	/// <summary>
//	/// Gestion des contacts avec l'environnement
//	/// </summary>
//	/// <param name="other"></param>
//	private void OnTriggerEnter(Collider other)
//	{
//		if (Active)
//		{
//			// Condition de fin de la partie
//			if ((other.CompareTag(Tags.Obstacle) || other.CompareTag(Tags.Enemy)))
//			{
//				// Le joueur rencontre un obstacle, une alerte est affichée
//				Invoke(nameof(SetCollision), 4);
//				StateContainer.SetState(StumbleState);
//				CharacterController.Move(-25 * Time.deltaTime * transform.forward);
//			}
//		}
//	}
//}
