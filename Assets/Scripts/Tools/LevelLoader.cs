using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] Animator Animator;
	[SerializeField] float TransitionTime;
	[SerializeField] bool IntroTransition;
	[SerializeField] bool OuttroTransition;
	[SerializeField] GameObject ProgressBar;

	private void Awake()
	{
		Debug.Assert(Animator != null, gameObject.name + "/Animator not set");
		Debug.Assert(TransitionTime != 0, gameObject.name + "/TransitionTime not set");
		Debug.Assert(ProgressBar != null, gameObject.name + "/ProgressBar not set");
	}

	private void Start()
    {
		ProgressBar.SetActive(false);
		if (IntroTransition)
		{
			Animator.SetTrigger("Intro");
			Invoke(nameof(DisableTransitionPanel), TransitionTime);
		}
	}

	public void LoadNextLevel(string newLevel)
	{
		StartCoroutine(TransitionToNextLevel(newLevel));
	}

	private void DisableTransitionPanel()
	{
		Animator.gameObject.SetActive(false);
	}

	private IEnumerator TransitionToNextLevel(string newLevel)
	{
		Animator.gameObject.SetActive(true);
		if (OuttroTransition)
		{
			Animator.SetTrigger("Outtro");
			yield return new WaitForSeconds(TransitionTime);
		}
		yield return StartCoroutine(AsyncTransitionToNextLevel(newLevel));
	}

	private IEnumerator AsyncTransitionToNextLevel(string newLevel)
	{
		ProgressBar.SetActive(true);
		AsyncOperation operation = SceneManager.LoadSceneAsync(newLevel);
		Slider slider = ProgressBar.GetComponentInChildren<Slider>();
		while (!operation.isDone)
		{
			slider.value = Mathf.Clamp01(operation.progress / 0.9f);
			yield return null;
		}
		ProgressBar.SetActive(false);
	}
}
