using UnityEngine;

/// <summary>
/// Objet ramassable pour le joueur
/// </summary>
public class Collectable : MonoBehaviour
{
	/// <summary>
	/// Son joué lors du ramassage
	/// </summary>
	[SerializeField] protected AudioSource AudioSource;
	[SerializeField] protected Renderer Renderer;
	[SerializeField] protected ParticleSystem Particles;
	[SerializeField] protected GameObject Lightning;
	[SerializeField] protected GameObject FloatingText;

	protected TextMesh FloatingTextMesh;
	protected float DelayTime;
	private Vector3 InitialTextPosition;

	private void Awake()
	{
		WhenAwake();
	}

	/// <summary>
	///  Récupération de la durée du son, pour désactiver l'objet après le son
	/// </summary>
	private void Start()
	{
		WhenStart();
	}

	/// <summary>
	/// Gestion du rammassage par le joueur
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		// Le joueur ramasse cet objet
		if (other.CompareTag(Tags.Player))
		{
			WhenTriggerEnter(other);
		}
	}

	/// <summary>
	/// Quand le collectable est activé, on active son renderer
	/// </summary>
	private void OnEnable()
	{
		WhenOnEnable();
	}

	protected virtual void WhenAwake()
	{
		Debug.Assert(AudioSource != null, gameObject.name + "/AudioSource not set");
		Debug.Assert(Renderer != null, gameObject.name + "/Renderer not set");
		Debug.Assert(Particles != null, gameObject.name + "/Particles not set");
		Debug.Assert(Lightning != null, gameObject.name + "/Lightning not set");
		Debug.Assert(FloatingText != null, gameObject.name + "/FloatingText not set");

		FloatingTextMesh = FloatingText?.GetComponent<TextMesh>();
		Debug.Assert(FloatingTextMesh != null, gameObject.name + "/FloatingText/TextMesh not set");
	}

	protected virtual void WhenStart()
	{
		DelayTime = AudioSource.clip.length;
		InitialTextPosition = FloatingTextMesh.transform.localPosition;
	}

	protected virtual void WhenTriggerEnter(Collider other)
	{
		Lightning.SetActive(true);
		FloatingText.SetActive(true);

		AudioSource.Play();
		Particles.Play();
		Renderer.enabled = false;
		Invoke(nameof(DelayedDisable), DelayTime);
	}

	protected virtual void WhenOnEnable()
	{
		Lightning.SetActive(false);
		FloatingText.SetActive(false);
		Renderer.enabled = true;
		FloatingTextMesh.transform.localPosition = InitialTextPosition;
	}

	/// <summary>
	/// Les collectables ne sont pas détruits, pour pouvoir être ré-activés plus tard
	/// pour éviter des instanciations trop nombreuses
	/// </summary>
	/// <returns></returns>
	protected virtual void DelayedDisable()
	{
		gameObject.SetActive(false);
	}
}
