using UnityEngine;

public class StateContainer : IStateContainer
{
	public IStateItem State { get; protected set; }

	public StateContainer() { }

	public void SetState(IStateItem newState)
	{
		State?.Exit();
		State = newState;
		State?.Enter();
	}

	public void Update()
	{
		State.Update();
	}

	public void OnMove(Vector2 move)
	{
		State.OnMove(move);
	}
}
