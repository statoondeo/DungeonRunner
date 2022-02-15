using UnityEngine;

[CreateAssetMenu(fileName = "New Player Sound Model", menuName = "Dungeon Escape/Player Sound Model")]
public class PlayerSoundModel : ScriptableObject
{
	public AudioClip RunningSound;
	public AudioClip JumpingSound;
	public AudioClip SlidingSound;
	public AudioClip DyingSound;
}

