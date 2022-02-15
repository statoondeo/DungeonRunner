using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
	[SerializeField] private PlayerSoundModel PlayerSoundModel;
	[SerializeField] private PlayerSoundView PlayerSoundView;

	private void Awake()
	{
		if (null == PlayerSoundModel) throw new System.ArgumentNullException("PlayerSoundModel is missing!");
		if (null == PlayerSoundView) throw new System.ArgumentNullException("PlayerSoundView is missing!");
	}

	public void PlayRunningSound(AnimationEvent myEvent)
	{
		PlayerSoundView.RunningAudioSource.PlayOneShot(PlayerSoundModel.RunningSound);
	}

	public void PlayJumpingSound()
	{
		PlayerSoundView.AudioSource.PlayOneShot(PlayerSoundModel.JumpingSound);
	}

	public void PlaySlidingSound()
	{
		PlayerSoundView.AudioSource.PlayOneShot(PlayerSoundModel.SlidingSound);
	}

	public void PlayDyingSound()
	{
		PlayerSoundView.AudioSource.PlayOneShot(PlayerSoundModel.DyingSound);
	}

	public void OnSpeedChanged(PlayerModel playerModel)
	{
		PlayerSoundView.RunningAudioSource.pitch = playerModel.ForwardSpeed / playerModel.InitialForwardSpeed;
	}
}
