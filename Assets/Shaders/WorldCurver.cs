using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver : MonoBehaviour
{
	// ID des variables du shader à modifier
	private int m_CurveXStrengthID;
	private int m_CurveYStrengthID;

	// Paramétrage de la courbure verticale
	[SerializeField] private float InitialVerticalCurve = 0.0f;
	[SerializeField] private Vector2 VerticalCurveTtlBounds;
	[SerializeField] private Vector2 VerticalCurveBounds;

	// Paramétrage de la courbure horizontale
	[SerializeField] private float InitialHorizontalCurve = 0.0f;
	[SerializeField] private Vector2 HorizontalCurveTtlBounds;
	[SerializeField] private Vector2 HorizontalCurveBounds;

	private void OnEnable()
    {
		m_CurveXStrengthID = Shader.PropertyToID("_CurveXStrength");
		m_CurveYStrengthID = Shader.PropertyToID("_CurveYStrength");
	}

	private void Start()
	{
		StartCoroutine(PerformVerticalCurve(m_CurveYStrengthID, VerticalCurveBounds, VerticalCurveTtlBounds, InitialVerticalCurve));
		StartCoroutine(PerformVerticalCurve(m_CurveXStrengthID, HorizontalCurveBounds, HorizontalCurveTtlBounds, InitialHorizontalCurve));
	}

	private IEnumerator PerformVerticalCurve(int curveId, Vector2 valueBounds, Vector2 ttlBounds, float initialCurve)
	{
		float ttl = 0;
		float PreviousVerticalCurve = initialCurve;
		float nextCurve = Random.Range(valueBounds.x, valueBounds.y);
		float maxTtl = Random.Range(ttlBounds.x, ttlBounds.y);
		while (ttl <= maxTtl)
		{
			ttl += Time.deltaTime;
			Shader.SetGlobalFloat(curveId, Mathf.Lerp(PreviousVerticalCurve, nextCurve, ttl / maxTtl));
			yield return null;
		}
		Shader.SetGlobalFloat(curveId, nextCurve);
		yield return StartCoroutine(PerformVerticalCurve(curveId, valueBounds, ttlBounds, nextCurve));
	}
}
