using UnityEngine;

/// <summary>
/// Classe permettant de décrire le comportement du boost de vitesse
/// </summary>
public class SpeedCollectable : Collectable
{
	[SerializeField] private SpeedModel SpeedModel;
	[SerializeField] private PlayerModel PlayerModel;
	[SerializeField] private GameEvent OnSpeedChanged;

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

	#endregion

	#region Comportement du collectable

	private void OnEnable()
	{
		WhenOnEnable();
	}

	protected override void WhenAwake()
	{
		base.WhenAwake();
		if (null == SpeedModel) throw new System.ArgumentNullException("SpeedModel is missing!");
		if (null == PlayerModel) throw new System.ArgumentNullException("PlayerModel is missing!");
		if (null == OnSpeedChanged) throw new System.ArgumentNullException("OnSpeedChanged is missing!");
	}

	protected override void WhenStart()
	{
		base.WhenStart();
		FloatingTextMesh.text = "Vitesse augmentée";
	}

	protected override void WhenTriggerEnter(Collider other)
	{
		base.WhenTriggerEnter(other);
		PlayerModel.Speed++;
		PlayerModel.ForwardSpeed *= SpeedModel.Multiplier;
		OnSpeedChanged.Raise();
	}

	#endregion
}
