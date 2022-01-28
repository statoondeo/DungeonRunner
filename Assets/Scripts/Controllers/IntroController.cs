using System.Collections;
using UnityEngine;

/// <summary>
/// Classe permettant de centraliser les comportement de l'intro du jeu
/// </summary>
public class IntroController : MonoBehaviour
{
    [SerializeField] LevelLoader LevelLoader;
    [SerializeField] float Duration;

	private void Awake()
	{
        Debug.Assert(LevelLoader != null, gameObject.name + "/LevelLoader not set");
        Debug.Assert(Duration != 0, gameObject.name + "/Duration not set");
    }

    private void Start()
    {
        StartCoroutine(LoadNextLevel());
    }

    /// <summary>
    /// Chargement de la scène Menu après une durée d'attente
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(Duration);
        LevelLoader.LoadNextLevel("Menu");
    }
}
