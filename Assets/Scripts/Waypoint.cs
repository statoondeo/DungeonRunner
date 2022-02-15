using UnityEngine;

public class Waypoint : MonoBehaviour
{
	[SerializeField] private Sentry Sentry;
	[SerializeField] private Transform Target;

	private Collider SentryCollider;

	private void Awake()
	{
		SentryCollider = Sentry.GetComponent<Collider>();
		Debug.Assert(Sentry != null, gameObject.name + "/Sentry not set");
		Debug.Assert(Target != null, gameObject.name + "/Target not set");
		Debug.Assert(SentryCollider != null, gameObject.name + "/SentryCollider not set");
	}

	private void OnTriggerEnter(Collider other)
	{
		// Si la sentinelle surveillée rencontre le waypoint, on change sa destination
		if (other == SentryCollider)
		{
			Sentry.Target = Target;
        }
	}
}
