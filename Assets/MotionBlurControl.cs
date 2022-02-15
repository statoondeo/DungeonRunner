using UnityEngine.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;

public class MotionBlurControl : MonoBehaviour
{
	private Volume Volume;
	private MotionBlur MotionBlur;
	private float CurrentIntensity = 0.0f;
	private int CurrentStep = 0;
	[SerializeField] private int MaxNbStep = 10;

	private void Awake()
	{
		Volume = GetComponent<Volume>();
		Debug.Assert(Volume != null, gameObject.name + "/Volume not set");

		Volume.profile.TryGet<MotionBlur>(out MotionBlur);
		Debug.Assert(MotionBlur != null, gameObject.name + "/MotionBlur not set");
		Debug.Assert(MaxNbStep != 0, gameObject.name + "/MaxNbStep not set");
	}

	public void OnSpeedChangedCallback()
	{
		CurrentStep++;
		CurrentIntensity += 1 / (float)MaxNbStep;
		MotionBlur.intensity.value = Mathf.Clamp01(CurrentIntensity);
	}
}
