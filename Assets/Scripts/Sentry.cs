using UnityEngine;

public class Sentry : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private float MinSpeed;
    [SerializeField] private float MaxSpeed;

    private float CurrentSpeed;

	private void Awake()
	{
        Debug.Assert(Target != null, gameObject.name + "/Target not set");
        Debug.Assert(MinSpeed != 0, gameObject.name + "/MinSpeed not set");
        Debug.Assert(MaxSpeed != 0, gameObject.name + "/MaxSpeed not set");
    }

    private void Start()
    {
        CurrentSpeed = Random.Range(MinSpeed, MaxSpeed);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, CurrentSpeed * Time.deltaTime);
    }
}
