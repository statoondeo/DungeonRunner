using UnityEngine;

/// <summary>
/// Classe permettant de faire du pooling de GameObject
/// Pour éviter les instanciation en cours de jeu
/// </summary>
public class ObjectPool
{
	protected GameObject Model;
	protected GameObject[] GameObjects;
	protected int CurrentIndex;
	public int Capacity { get; protected set; }

	public ObjectPool(GameObject model, int capacity, Transform parentObject)
	{
		Capacity = capacity;
		GameObjects = new GameObject[Capacity];
		Model = model;
		for (int i = 0; i < Capacity; i++)
		{
			GameObjects[i] = GameObject.Instantiate(Model);
			GameObjects[i].SetActive(false);
			GameObjects[i].transform.parent = parentObject;
		}
		CurrentIndex = 0;
	}

	public void Reset()
	{
		for (int i = 0; i < Capacity; i++)
		{
			GameObjects[i].SetActive(false);
		}
	}

	public GameObject Get()
	{
		int read = 0;
		while (GameObjects[CurrentIndex].activeSelf && read < Capacity)
		{
			read++;
			CurrentIndex++;
			CurrentIndex %= Capacity;
		}
		if (read >= Capacity)
		{
			// Pool mal dimensionné
			Debug.Log("Pool mal dimensionné!");
			return (GameObject.Instantiate(Model));
		}
		else
		{
			return (GameObjects[CurrentIndex]);
		}
	}
}
