using UnityEngine;

public class Sentry : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private Animator Animator;
    [SerializeField] private float MinSpeed;
    [SerializeField] private float MaxSpeed;

    private float CurrentSpeed;

    private void Awake()
	{
        Debug.Assert(Target != null, gameObject.name + "/Target not set");
        Debug.Assert(Animator != null, gameObject.name + "/Animator not set");
        Debug.Assert(MinSpeed != 0, gameObject.name + "/MinSpeed not set");
        Debug.Assert(MaxSpeed != 0, gameObject.name + "/MaxSpeed not set");
    }

    /// <summary>
    /// Détermination de la vitesse de base du monstre
    /// </summary>
    private void Start()
    {
        CurrentSpeed = Random.Range(MinSpeed, MaxSpeed);
    }

    /// <summary>
    /// Le monstre navigue en suivant les différentes balises de son parcours
    /// </summary>
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, CurrentSpeed * Time.deltaTime);
        transform.LookAt(Target.position);
    }

    /// <summary>
    /// Si le monstre entre en collision avec le joueur, on désactive les mouvements du monstre
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag(Tags.Player))
        {
            Animator.SetTrigger(PlayerAnimationTriggers.Dance);
            transform.LookAt(other.transform.position);
            enabled = false;
        }
	}
}
