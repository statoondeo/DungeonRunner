/// <summary>
/// Classe permettant de g�rer les �tats du jeu, sous forme d'un singleton
/// </summary>
public class GameManager : MonoBehaviourSingleton<GameManager>
{
	// Score actuel
	public int Score;

	// Score maximum jusque maintenant
	public int MaxScore;
}
