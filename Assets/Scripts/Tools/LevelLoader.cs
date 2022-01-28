using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] Animator Animator;
	[SerializeField] float TransitionTime;
	[SerializeField] bool IntroTransition;
	[SerializeField] bool OuttroTransition;

	private void Awake()
	{
		Debug.Assert(Animator != null, gameObject.name + "/Animator not set");
		Debug.Assert(TransitionTime != 0, gameObject.name + "/TransitionTime not set");
	}

	private void Start()
    {
		Animator.ResetTrigger("Outtro");
		if (IntroTransition)
		{
			Animator.SetTrigger("Intro");
		}
	}

	public void LoadNextLevel(string newLevel)
	{
		StartCoroutine(TransitionToNextLevel(newLevel));
	}

	private IEnumerator TransitionToNextLevel(string newLevel)
	{
		Animator.ResetTrigger("Intro");
		if (OuttroTransition)
		{
			Animator.SetTrigger("Outtro");
		}
		yield return new WaitForSeconds(TransitionTime);
		SceneManager.LoadScene(newLevel);
	}
}
