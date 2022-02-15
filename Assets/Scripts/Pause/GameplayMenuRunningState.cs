using UnityEngine;

public class GameplayMenuRunningState : BaseGameplayMenuState
{
	public GameplayMenuRunningState(IStateContainer container, string nextStatename, GameObject pausePanel)
		: base(container, nextStatename, pausePanel)
	{
		IsPaused = false;
	}

	public override void Enter()
	{
		base.Enter();
		PausePanel.SetActive(IsPaused);
		Time.timeScale = 1.0f;
	}
}
