using UnityEngine;

/// <summary>
/// Classe permettant de décrire le comportement des pièces à ramasser
/// </summary>
public class CoinCollectable : Collectable
{
	[SerializeField] private GoldModel GoldModel;
	[SerializeField] private PlayerModel PlayerModel;
	[SerializeField] private GameEvent OnScoreChanged;

	#region Gestion des messages Unity

	private void Awake()
	{
		WhenAwake();
	}

	private void Start()
	{
		WhenStart();
	}

	private void OnTriggerEnter(Collider other)
	{
		// Le joueur ramasse cet objet
		if (other.CompareTag(Tags.Player))
		{
			WhenTriggerEnter(other);
		}
	}

	private void OnEnable()
	{
		WhenOnEnable();
	}

	#endregion

	#region Comportement du collectable

	protected override void WhenAwake()
	{
		base.WhenAwake();
		if (null == GoldModel) throw new System.ArgumentNullException("GoldModel is missing!");
		if (null == PlayerModel) throw new System.ArgumentNullException("PlayerModel is missing!");
		if (null == OnScoreChanged) throw new System.ArgumentNullException("OnScoreChanged is missing!");
		AudioSource.clip = GoldModel.AudioClip;
	}

	protected override void WhenOnEnable()
	{
		base.WhenOnEnable();
		GoldModel.Score = GoldModel.BaseScore * PlayerModel.Speed;
	}

	protected override void WhenTriggerEnter(Collider other)
	{
		base.WhenTriggerEnter(other);
		FloatingTextMesh.text = "+" + GoldModel.Score;
		PlayerModel.Score += GoldModel.Score;
		OnScoreChanged.Raise();
	}

	// Le joueur a ramassé des gold
	public void OnPlayerSpeedChanged(PlayerModel playerModel)
	{
		GoldModel.Score = GoldModel.BaseScore * PlayerModel.Speed;
	}

	#endregion
}
