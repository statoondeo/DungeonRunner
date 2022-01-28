using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe permettant de centraliser le comportement du menu du jeu
/// </summary>
public class MenuController : MonoBehaviour
{
	[SerializeField] private LevelLoader LevelLoader;
	[SerializeField] private Text LevelBestScoreLoader;

	private void Awake()
	{
		Debug.Assert(LevelLoader != null, gameObject.name + "/LevelLoader not set");
		Debug.Assert(LevelBestScoreLoader != null, gameObject.name + "/LevelBestScoreLoader not set");
	}

	private void Start()
	{
		GameManager.Instance.MaxScore = PlayerPrefs.GetInt("MaxScore");
		LevelBestScoreLoader.text = "Meilleur score : " + GameManager.Instance.MaxScore;
	}

	/// <summary>
	/// Comportement � ex�cuter lors du click sur le bouton "Play" du menu
	/// </summary>
	public void OnPlayClick()
    {
        // Chargement de la sc�ne Gameplay
        LevelLoader.LoadNextLevel("Gameplay");
    }
}
