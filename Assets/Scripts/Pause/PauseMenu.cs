using UnityEngine;

public class PauseMenu : MonoBehaviour, IPauseState
{
	protected StateContainer StateContainer;
	protected IGameplayState RunningState;

	#region IPauseState

	public bool IsPaused => (StateContainer.State as IGameplayState).IsPaused;

	#endregion

	[SerializeField] private GameObject PausePanel;
	[SerializeField] private LevelLoader LevelLoader;

	private void Awake()
    {
		Debug.Assert(PausePanel != null, gameObject.name + "/PausePanel not set");
		Debug.Assert(LevelLoader != null, gameObject.name + "/LevelLoader not set");
	}

	private void Start()
	{
		StateContainer = new StateContainer();
		IGameplayState pauseState = new GameplayMenuPausingState(StateContainer, "Running", PausePanel);
		RunningState = new GameplayMenuRunningState(StateContainer, "Paused", PausePanel);
		pauseState.AddTransition("Running", RunningState);
		RunningState.AddTransition("Paused", pauseState);
		StateContainer.SetState(RunningState);
	}

	public void Update()
    {
		StateContainer.Update();
	}

	public void OnMenu()
	{
		StateContainer.SetState(RunningState);
		LevelLoader.LoadNextLevel("Menu");
	}

	public void OnContinue()
	{
		StateContainer.SetState(RunningState);
	}
}
