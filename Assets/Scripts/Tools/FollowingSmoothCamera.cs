using UnityEngine;

public class FollowingSmoothCamera : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private Vector3 PositionOffset;
    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float RefreshTime;

    private void Awake()
    {
        Debug.Assert(Target != null, gameObject.name + "/Target not set");
        Debug.Assert(PositionOffset != Vector3.zero, gameObject.name + "/PositionOffset not set");
        Debug.Assert(TargetOffset != Vector3.zero, gameObject.name + "/TargetOffset not set");
        Debug.Assert(RefreshTime != 0, gameObject.name + "/RefreshTime not set");
    }

	private void LateUpdate()
	{
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + PositionOffset, RefreshTime);
        transform.LookAt(Target.transform.position + TargetOffset);
    }
}
