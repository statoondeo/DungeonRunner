using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script permettant de contrôler l'interface in game du jeu
/// </summary>
public class InGameUI : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text BestScoreText;
    [SerializeField] private Text CoinText;
    [SerializeField] private Text CollisionAlertText;
    [SerializeField] private float CollisionAlertTtl;

    private float BestScore;

	private void Awake()
	{
        Debug.Assert(ScoreText != null, gameObject.name + "/ScoreText not set");
        Debug.Assert(BestScoreText != null, gameObject.name + "/BestScoreText not set");
        Debug.Assert(CoinText != null, gameObject.name + "/CoinText not set");
        Debug.Assert(CollisionAlertText != null, gameObject.name + "/CollisionAlertText not set");
        Debug.Assert(CollisionAlertTtl != 0, gameObject.name + "/CollisionAlertTtl not set");
    }

    private void Start()
    {
        BestScore = GameManager.Instance.MaxScore;
        BestScoreText.text = "Meilleur : " + (int)BestScore;
    }

    /// <summary>
    /// Affichage du score
    /// </summary>
    public void SetScore(float score)
    {
        ScoreText.text = "Score : " + (int)score;
        if (score >= BestScore)
        {
            BestScoreText.text = "Meilleur : " + (int)score;
        }
    }

    /// <summary>
    /// Affichage du compteur de collectables
    /// </summary>
    public void SetCoin(float score)
    {
        CoinText.text = "Pièces : " + (int)score;
    }

    /// <summary>
    /// Affichage d'une alerte indiquant que le joueur a été touché par un obstacle
    /// </summary>
    public void SetCollisionAlert()
    {
        StartCoroutine(ShowAlert(CollisionAlertText.gameObject, CollisionAlertTtl));
    }

    /// <summary>
    /// Affichae d'une alerte dans l'UI
    /// </summary>
    /// <param name="gameObject">GameObject contenant les éléments de l'alerte</param>
    /// <param name="duration">Durée d'affichage de l'alerte</param>
    /// <returns></returns>
    private IEnumerator ShowAlert(GameObject gameObject, float duration)
    {
        float currentTtl = 0;
        gameObject.SetActive(true);
        while (currentTtl < duration)
		{
            currentTtl += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
