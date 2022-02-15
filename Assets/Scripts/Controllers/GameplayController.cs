using System.Collections;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
	[SerializeField] private GameEvent OnSpeedChanged;
	[SerializeField] private GameEvent OnScoreChanged;
	[SerializeField] private GameEvent OnMaxScoreChanged;
	[SerializeField] private GameplayModel GameplayModel;
	[SerializeField] private LevelLoader LevelLoader;
	[SerializeField] private PlayerModel PlayerModel;

	private void Awake()
	{
		if (null == OnSpeedChanged) throw new System.ArgumentNullException("OnSpeedChanged is missing!");
		if (null == OnScoreChanged) throw new System.ArgumentNullException("OnScoreChanged is missing!");
		if (null == OnMaxScoreChanged) throw new System.ArgumentNullException("OnMaxScoreChanged is missing!");
		if (null == GameplayModel) throw new System.ArgumentNullException("GameplayModel is missing!");
		if (null == LevelLoader) throw new System.ArgumentNullException("LevelLoader is missing!");
		if (null == PlayerModel) throw new System.ArgumentNullException("PlayerModel is missing!");
	}

	private void Start()
	{
		// Initialisation des données
		PlayerModel.Active = true;
		GameManager.Instance.LastScore = PlayerModel.Score = 0;
		PlayerModel.Speed = 1;
		PlayerModel.ForwardSpeed = PlayerModel.InitialForwardSpeed;
		GameplayModel.MaxScore = GameManager.Instance.MaxScore;

		OnScoreChanged.Raise();
		OnSpeedChanged.Raise();
		OnMaxScoreChanged.Raise();
	}

	private IEnumerator GotoEndScene()
	{
		yield return (new WaitForSeconds(3));
		LevelLoader.LoadNextLevel("End");
	}

	public void OnScoreChangedCallback(PlayerModel playerModel)
	{
		if (playerModel.Score > GameplayModel.MaxScore)
		{
			GameplayModel.MaxScore = playerModel.Score;
			OnMaxScoreChanged.Raise();
		}
	}

	public void OnPlayerDeadCallback(PlayerModel playerModel)
	{
		GameManager.Instance.LastScore = playerModel.Score;
		StartCoroutine(GotoEndScene());
	}
}
