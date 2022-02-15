using UnityEngine;

public abstract class BaseGameplayMenuState : StateItem, IGameplayState
{
	protected private GameObject PausePanel;
	protected private string NextStatename;
	public bool IsPaused { get; protected set; }

	public BaseGameplayMenuState(IStateContainer container, string nextStatename, GameObject pausePanel)
		: base(container)
	{
		NextStatename = nextStatename;
		PausePanel = pausePanel;
	}
	public override void Update()
	{
		base.Update();
		//if (Input.GetKeyDown(KeyCode.Escape))
		//{
		//	Container.SetState(Transitions[NextStatename]);
		//}
	}
}
