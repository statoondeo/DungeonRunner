using UnityEngine;

public class FollowingSmoothCamera : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private Vector3 PositionOffset;
    [SerializeField] private Vector3 PositionOffsetMobile;
    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float RefreshTime;

    private Vector3 TargetPositionOffset;
    private bool PlayerDead = false;

    private void Awake()
    {
        Debug.Assert(Target != null, gameObject.name + "/Target not set");
        Debug.Assert(PositionOffset != Vector3.zero, gameObject.name + "/PositionOffset not set");
        Debug.Assert(PositionOffsetMobile != Vector3.zero, gameObject.name + "/PositionOffsetMobile not set");
        Debug.Assert(TargetOffset != Vector3.zero, gameObject.name + "/TargetOffset not set");
        Debug.Assert(RefreshTime != 0, gameObject.name + "/RefreshTime not set");
    }

	private void Start()
	{
        TargetPositionOffset = Screen.height > Screen.width ? PositionOffsetMobile : PositionOffset;

    }

	private void LateUpdate()
	{
        if (!PlayerDead)
        {
            transform.position = Vector3.Lerp(transform.position, Target.transform.position + TargetPositionOffset, RefreshTime * Time.deltaTime);
            transform.LookAt(Target.transform.position + TargetOffset);
        }
    }

    public void OnPlayerDeadCallBack(PlayerModel playerModel)
	{
        transform.LookAt(Target.transform.position);
        PlayerDead = true;
    }
}
