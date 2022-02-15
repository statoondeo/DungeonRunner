using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script permettant de contrôler l'interface in game du jeu
/// </summary>
public class InGameUI : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text SpeedText;
    [SerializeField] private Text BestScoreText;

    private int BestScore;

	private void Awake()
	{
        if (null == ScoreText) throw new System.ArgumentNullException("ScoreText is missing!");
        if (null == SpeedText) throw new System.ArgumentNullException("SpeedText is missing!");
        if (null == BestScoreText) throw new System.ArgumentNullException("BestScoreText is missing!");
    }

    /// <summary>
    /// Affichage du score
    /// </summary>
    public void OnScoreChanged(PlayerModel playerModel)
    {
        ScoreText.text = playerModel.Score.ToString();
    }

    /// <summary>
    /// Affichage du meilleur score
    /// </summary>
    public void OnBestScoreChanged(GameplayModel gameplayModel)
    {
        BestScoreText.text = gameplayModel.MaxScore.ToString();
    }

    /// <summary>
    /// Affichage du score
    /// </summary>
    public void OnSpeedChanged(PlayerModel playerModel)
    {
        SpeedText.text = playerModel.Speed.ToString();
    }
}
