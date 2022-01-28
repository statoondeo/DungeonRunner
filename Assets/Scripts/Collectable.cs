using UnityEngine;
using static UnityEngine.ParticleSystem;

/// <summary>
/// Objet ramassage pour le joueur
/// </summary>
public class Collectable : MonoBehaviour
{
	/// <summary>
	/// Son jou� lors du ramassage
	/// </summary>
	[SerializeField] private AudioSource AudioSource;
	[SerializeField] private Renderer Renderer;
	[SerializeField] private ParticleSystem Particles;

	private float DelayTime;

	private void Awake()
	{
		Debug.Assert(AudioSource != null, gameObject.name + "/AudioSource not set");
		Debug.Assert(Renderer != null, gameObject.name + "/Renderer not set");
		Debug.Assert(Particles != null, gameObject.name + "/Particles not set");
	}

	/// <summary>
	///  R�cup�ration de la dur�e du son, pour d�sactiver l'objet apr�s le son
	/// </summary>
	private void Start()
	{
		DelayTime = AudioSource.clip.length;
	}

	/// <summary>
	/// Les collectables ne sont pas d�truits, pour pouvoir �tre r�-activ�s plus tard
	/// pour �viter des instanciations trop nombreuses
	/// </summary>
	/// <returns></returns>
	private void DelayedDisable()
	{
		gameObject.SetActive(false);
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
			AudioSource.Play();
			Renderer.enabled = false;
			Particles.Play();
			Invoke(nameof(DelayedDisable), DelayTime);
		}
	}

	/// <summary>
	/// Quand le collectable est activ�, on active son renderer
	/// </summary>
	private void OnEnable()
	{
		Renderer.enabled = true;
	}
}
