using UnityEngine;

public class GameplayMenuPausingState : BaseGameplayMenuState
{
	public GameplayMenuPausingState(IStateContainer container, string nextStatename, GameObject pausePanel)
		: base(container, nextStatename, pausePanel)
	{
		IsPaused = true;
	}

	public override void Enter()
	{
		base.Enter();
		PausePanel.SetActive(IsPaused);
		Time.timeScale = 0.0f;
	}
}
