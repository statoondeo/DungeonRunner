using System.Collections.Generic;
using UnityEngine;

public class StateItem : IStateItem
{
	protected IDictionary<string, IStateItem> Transitions;

	public IStateContainer Container { get; protected set; }

	public StateItem(IStateContainer container)
	{
		Transitions = new Dictionary<string, IStateItem>();
		Container = container;
	}

	public virtual void Enter() { }

	public virtual void Exit() { }

	public virtual void Update() { }

	public void AddTransition(string name, IStateItem newState)
	{
		Transitions.Add(name, newState);
	}
	public virtual void OnMove(Vector2 move) { }

	public virtual void OnTriggerEnter(Collider other) { }
}



