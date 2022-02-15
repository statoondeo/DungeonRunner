using UnityEngine;

[CreateAssetMenu(fileName = "New Player Model", menuName = "Dungeon Escape/Player Model")]

public class PlayerModel : ScriptableObject
{
	public int Score;
	public int Speed;
	[HideInInspector] public Vector3 Position;
	[HideInInspector] public Vector3 NextMove;
	[HideInInspector] public bool Active;

	// Gravité artificielle
	public float Gravity;

	// Mouvement vers l'avant initial
	public float InitialForwardSpeed;
	[HideInInspector] public float ForwardSpeed;

	// Gestion des mouvements verticaux
	public float JumpHeight;
	public float SlidingDuration;

	// Gestion des mouvements latéraux
	public float LaneWidth;
	public float LaningDuration;

	private void OnEnable()
	{
		ForwardSpeed = InitialForwardSpeed;
		Active = false;
		NextMove = Vector3.zero;
		Position = Vector3.zero;
		Speed = 1;
		Score = 0;
	}
}
