using UnityEngine;

/// <summary>
/// Classe permettant de centraliser le comportement du menu du jeu
/// </summary>
public class EndController : MonoBehaviour
{
    [SerializeField] LevelLoader LevelLoader;
    [SerializeField] Animator PlayerAnimator;

    private void Awake()
	{
        Debug.Assert(LevelLoader != null, gameObject.name + "/LevelLoader not set");
        Debug.Assert(PlayerAnimator != null, gameObject.name + "/PlayerAnimator not set");
    }

    /// <summary>
    /// Sauvegarde du score si c'est le meilleur
    /// </summary>
    private void Start()
	{
		//      if (GameManager.Instance.Score > GameManager.Instance.MaxScore)
		//{
		PlayerPrefs.SetInt("MaxScore", GameManager.Instance.Score);
		PlayerAnimator.SetTrigger(PlayerCharacterAnimationTriggers.Dance);
		//      }
		//      else
		//{
		//          PlayerAnimator.SetTrigger(PlayerCharacterAnimationTriggers.Cry);
		//      }
	}

    /// <summary>
    /// Comportement � ex�cuter lors du click sur le bouton "Play"
    /// </summary>
    public void OnPlayClick()
    {
        // Chargement de la sc�ne Gameplay
        LevelLoader.LoadNextLevel("Gameplay");
    }

    /// <summary>
    /// Comportement � ex�cuter lors du click sur le bouton "Menu"
    /// </summary>
    public void OnMenuClick()
    {
        // Chargement de la sc�ne Gameplay
        LevelLoader.LoadNextLevel("Menu");
    }
}
