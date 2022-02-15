using UnityEngine;

[CreateAssetMenu(fileName="New Gameplay Model", menuName="Dungeon Escape/Gameplay Model")]
public class GameplayModel : ScriptableObject
{
	public bool IsStarted;
	public bool IsEnded;
	public int MaxScore;

	private void OnEnable()
	{
		IsStarted = false;
		IsEnded = false;
		MaxScore = 0;
	}
}

