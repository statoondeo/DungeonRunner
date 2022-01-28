using UnityEngine;

public interface IStateItem
{
	IStateContainer Container { get; }
	void AddTransition(string name, IStateItem newState);
	void Enter();
	void Update();
	void OnTriggerEnter(Collider other);
	void Exit();
}
