using UnityEngine;

public interface IStateContainer
{
	IStateItem State { get; }
	void SetState(IStateItem newState);
	void Update();
	void OnMove(Vector2 move);
}
