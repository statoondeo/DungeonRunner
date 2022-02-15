using UnityEngine.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class LensControl : MonoBehaviour
{
	private Volume Volume;
	private LensDistortion LensDistortion;

	private void Awake()
	{
		Volume = GetComponent<Volume>();
		Debug.Assert(Volume != null, gameObject.name + "/Volume not set");

		Volume.profile.TryGet<LensDistortion>(out LensDistortion);
		Debug.Assert(LensDistortion != null, gameObject.name + "/LensDistortion not set");
	}

	public void StartEffect()
	{
		LensDistortion.active = true;
		StartCoroutine(FirstStep());
	}

	private IEnumerator FirstStep()
	{
		LensDistortion.intensity.value = 0.01f;
		float maxTtl = 0.25f;
		float ttl = 0;
		while (ttl <= maxTtl)
		{
			LensDistortion.scale.value = 1.0f + Tweening.QuintInStep(ttl / maxTtl);
			ttl += Time.deltaTime;
			yield return null;
		}
		LensDistortion.scale.value = 2.0f;
		yield return StartCoroutine(SecondStep());
	}

	private IEnumerator SecondStep()
	{
		float maxTtl = 0.25f;
		float ttl = 0;
		while (ttl <= maxTtl)
		{
			LensDistortion.scale.value = 2.0f - Tweening.ElasticOutStep(ttl / maxTtl);
			ttl += Time.deltaTime;
			yield return null;
		}
		LensDistortion.scale.value = 1.0f;
		LensDistortion.intensity.value = 0.0f;
		LensDistortion.active = false;
	}

}
