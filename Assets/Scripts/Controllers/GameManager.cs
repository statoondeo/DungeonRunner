/// <summary>
/// Classe permettant de gérer les états du jeu, sous forme d'un singleton
/// </summary>
public class GameManager : MonoBehaviourSingleton<GameManager>
{
	// Score actuel
	public int Score;

	// Score maximum jusque maintenant
	public int MaxScore;
}
