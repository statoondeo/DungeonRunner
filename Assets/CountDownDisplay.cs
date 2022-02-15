using System.Collections;
using UnityEngine;

public class CountDownDisplay : MonoBehaviour
{
    [SerializeField] private float TransitionDuration;
    [SerializeField] private float Duration;
    [SerializeField] private CanvasGroup CanvasGroup;

	private void OnEnable()
	{
        StartCoroutine(FadeIn());
	}

    private IEnumerator FadeIn()
    {
        yield return StartCoroutine(Fade(0, 1));
        yield return (new WaitForSeconds(Duration));
        yield return StartCoroutine(Fade(1, 0));
        gameObject.SetActive(false);
    }

    private IEnumerator Fade(float from, float to)
    {
        float ttl = 0.0f;
        while (ttl < TransitionDuration)
        {
            ttl += Time.deltaTime;
            CanvasGroup.alpha = Mathf.Lerp(from, to, ttl / Duration);
            yield return (null);
        }
        CanvasGroup.alpha = to;
    }
}
