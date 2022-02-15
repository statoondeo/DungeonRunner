using UnityEngine;

[CreateAssetMenu(fileName = "New Gold Model", menuName = "Dungeon Escape/Gold Model")]
public class GoldModel : ScriptableObject
{
	public int BaseScore;
	public AudioClip AudioClip;
	[HideInInspector] public int Score;

	private void OnEnable()
	{
		Score = BaseScore;
	}
}

