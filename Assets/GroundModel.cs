using UnityEngine;

[CreateAssetMenu(fileName = "New Ground Model", menuName = "Dungeon Escape/Ground Model")]
public class GroundModel : ScriptableObject
{
	public int BoostStart;
	public int BoostStep;
	public int ActiveGrounds;
	public Ground[] GroundModels;
	public Ground[] TransitionModels;
}

