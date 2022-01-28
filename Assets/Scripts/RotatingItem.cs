using UnityEngine;

public class RotatingItem : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private Vector3 Speed;

    private void Awake()
    {
        Debug.Assert(Target != null, gameObject.name + "/Target not set");
        Debug.Assert(Speed != Vector3.zero, gameObject.name + "/Speed not set");
    }

    private void Update()
    {
        Target.transform.Rotate(Speed * Time.deltaTime);
    }
}
