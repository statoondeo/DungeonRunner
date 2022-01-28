public interface IStateContainer
{
	IStateItem State { get; }
	void SetState(IStateItem newState);
	void Update();
}
