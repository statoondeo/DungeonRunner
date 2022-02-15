using UnityEngine;

public class CameraFocalController : MonoBehaviour
{
	[SerializeField] private float Multiplier;
	[SerializeField] private Camera Camera;

	private void Awake()
	{
		Debug.Assert(Camera != null, gameObject.name + "/Camera not set");
		Debug.Assert(Multiplier != 0, gameObject.name + "/Multiplier not set");
	}

	public void GotoNextStep()
	{
		Camera.fieldOfView *= Multiplier;
	}
}
