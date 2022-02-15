using UnityEngine;

public class PlayerSoundView : MonoBehaviour
{
	public AudioSource RunningAudioSource;
	public AudioSource AudioSource;

	private void Awake()
	{
		if (null == RunningAudioSource) throw new System.ArgumentNullException("RunningAudioSource reference is missing!");
		if (null == AudioSource) throw new System.ArgumentNullException("AudioSource reference is missing!");
	}
}
