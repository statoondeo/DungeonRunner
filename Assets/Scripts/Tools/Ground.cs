using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comportement d'un terrain
/// </summary>
public class Ground : MonoBehaviour
{
    /// <summary>
    /// Objet fils contenant les collectables
    /// </summary>
    [SerializeField] private GameObject CollectablesContainer;

    /// <summary>
    /// Longueur du terrain (pour son recyclage par le GroundGenerator)
    /// </summary>
    public float Length;

    /// <summary>
    /// Liste des collectables du terrain qui seront activés/désactivés
    /// pour éviter de les instancier à chaque apparatition du terrain
    /// </summary>
    private IList<GameObject> Collectables;

    /// <summary>
    /// Création du container de collectables
    /// </summary>
	private void Awake()
	{
        Debug.Assert(CollectablesContainer != null, gameObject.name + "/CollectablesContainer not set");
        Collectables = new List<GameObject>();
    }

    /// <summary>
    /// Récupération de tous les collectables du terrain
    /// </summary>
	private void Start()
	{
		foreach (Transform child in CollectablesContainer.transform)
		{
            Collectables.Add(child.gameObject);
		}
        Init();
    }

    /// <summary>
    /// Quand le terrain est activé, on active tous les collectables qu'il contient
    /// </summary>
    private void OnEnable()
	{
        Init();
    }

    /// <summary>
    /// Quand le terrain est désactivé, on désactive tous les collectables qu'il contient
    /// </summary>
	private void OnDisable()
	{
        foreach (GameObject coin in Collectables)
        {
            coin.SetActive(false);
        }
    }

	public void Init()
	{
        foreach (GameObject coin in Collectables)
        {
            coin.SetActive(true);
            coin.transform.rotation = transform.rotation;
        }
    }
}
