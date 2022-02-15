using UnityEngine;

/// <summary>
/// Classe proposant les fonctions de tweening
/// </summary>
public static class Tweening
{

	public static float QuintInStep(float progress)
	{
		return progress * progress * progress * progress * progress;
	}

	
	public static float ElasticOutStep(float progress)
	{
		float c4 = (2 * Mathf.PI) / 3;

		return progress == 0
		  ? 0
		  : progress == 1
		  ? 1
		  : Mathf.Pow(2, -10 * progress) * Mathf.Sin((progress * 10 - 0.75f) * c4) + 1;
	}
}
