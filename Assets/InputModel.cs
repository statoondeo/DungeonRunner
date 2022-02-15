using UnityEngine;

[CreateAssetMenu(fileName = "New Input Model", menuName = "Dungeon Escape/Input Model")]
public class InputModel : ScriptableObject
{
	public float MinDragDistance;
	[HideInInspector] public Vector2 Swipe;
}

