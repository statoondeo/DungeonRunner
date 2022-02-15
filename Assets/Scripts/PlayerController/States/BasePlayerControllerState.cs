public abstract class BasePlayerControllerState : StateItem
{
	protected PlayerModel PlayerModel;
	protected PlayerView PlayerView;

	protected BasePlayerControllerState(IStateContainer container, PlayerModel playerModel, PlayerView playerView)
		: base(container)
	{
		PlayerModel = playerModel;
		PlayerView = playerView;
	}
}
