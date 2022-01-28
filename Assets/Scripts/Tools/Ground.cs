using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comportement d'un terrain
/// </summary>
public class Ground : MonoBehaviour
{
    [SerializeField] private GameObject CoinContainer;

    /// <summary>
    /// Liste des collectables du terrain qui seront activés/désactivés
    /// pour éviter de les instancier à chaque apparatition du terrain
    /// </summary>
    private IList<GameObject> Coins;

    /// <summary>
    /// Création du container de collectables
    /// </summary>
	private void Awake()
	{
        Coins = new List<GameObject>();
    }

    /// <summary>
    /// Récupération de tous les collectables du terrain
    /// </summary>
	private void Start()
	{
		for (int i = 0; i < CoinContainer.transform.childCount; i++)
		{
            Coins.Add(CoinContainer.transform.GetChild(i).gameObject);
		}
	}

    /// <summary>
    /// Quand le terrain est activé, on active tous les collectables qu'il contient
    /// </summary>
    private void OnEnable()
	{
		foreach(GameObject coin in Coins)
		{
            coin.SetActive(true);
		}
	}

    /// <summary>
    /// Quand le terrain est désactivé, on désactive tous les collectables qu'il contient
    /// </summary>
	private void OnDisable()
	{
        foreach (GameObject coin in Coins)
        {
            coin.SetActive(false);
        }
    }
}
