using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private LevelLoader LevelLoader;
    [SerializeField] private PlayerCharacterController PlayerCharacterController;
    [SerializeField] private InGameUI InGameUI;

	private void Awake()
	{
        Debug.Assert(LevelLoader != null, gameObject.name + "/LevelLoader not set");
        Debug.Assert(PlayerCharacterController != null, gameObject.name + "/PlayerCharacterController not set");
        Debug.Assert(InGameUI != null, gameObject.name + "/InGameUI not set");
    }

	/// <summary>
	/// Initialisation du score
	/// </summary>
	private void Start()
	{
		GameManager.Instance.Score = 0;
	}

	/// <summary>
	/// Mise à jour du score dans l'UI
	/// </summary>
	public void UpdateScore()
	{
        GameManager.Instance.Score++;
        InGameUI.SetScore(GameManager.Instance.Score);
	}

	/// <summary>
	/// Affichage d'une alerte indiquant que le joueur a été touché par un obstacle
	/// </summary>
	public void SetCollisionAlert()
    {
        //InGameUI.SetCollisionAlert();
        LevelLoader.LoadNextLevel("End");
    }
}
