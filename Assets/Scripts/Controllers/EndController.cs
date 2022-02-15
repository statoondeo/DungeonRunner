using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe permettant de centraliser le comportement du menu du jeu
/// </summary>
public class EndController : MonoBehaviour
{
    public bool IsPaused => false;

    [SerializeField] LevelLoader LevelLoader;
    [SerializeField] Animator PlayerAnimator;
    [SerializeField] Text Score;
    [SerializeField] Text Best;

    private void Awake()
	{
        Debug.Assert(LevelLoader != null, gameObject.name + "/LevelLoader not set");
        Debug.Assert(PlayerAnimator != null, gameObject.name + "/PlayerAnimator not set");
        Debug.Assert(Score != null, gameObject.name + "/Score not set");
        Debug.Assert(Best != null, gameObject.name + "/Best not set");
    }

    /// <summary>
    /// Sauvegarde du score si c'est le meilleur
    /// </summary>
    private void Start()
	{
        if (GameManager.Instance.LastScore > GameManager.Instance.MaxScore)
		{
            PlayerPrefs.SetInt("MaxScore", GameManager.Instance.LastScore);
			PlayerAnimator.SetTrigger(PlayerAnimationTriggers.Dance);
            GameManager.Instance.MaxScore = GameManager.Instance.LastScore;
        }
		else
		{
			PlayerAnimator.SetTrigger(PlayerAnimationTriggers.Cry);
		}
        Score.text = GameManager.Instance.LastScore.ToString();
        Best.text = GameManager.Instance.MaxScore.ToString();
    }

    /// <summary>
    /// Comportement à exécuter lors du click sur le bouton "Play"
    /// </summary>
    public void OnPlayClick()
    {
        // Chargement de la scène Gameplay
        LevelLoader.LoadNextLevel("Gameplay");
    }

    /// <summary>
    /// Comportement à exécuter lors du click sur le bouton "Menu"
    /// </summary>
    public void OnMenuClick()
    {
        // Chargement de la scène Gameplay
        LevelLoader.LoadNextLevel("Menu");
    }
}
