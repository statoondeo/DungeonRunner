using UnityEngine;

/// <summary>
/// Classe permettant de faire du pooling de GameObject
/// Pour éviter les instanciation en cours de jeu
/// </summary>
public class ObjectPool<T> where T : Component
{
	protected GameObject Model;
	protected T[] Objects;
	protected int CurrentIndex;
	public int Capacity { get; protected set; }

	public ObjectPool(GameObject model, int capacity, Transform parentObject)
	{
		Capacity = capacity;
		Objects = new T[Capacity];
		Model = model;
		for (int i = 0; i < Capacity; i++)
		{
			Objects[i] = GameObject.Instantiate(Model).GetComponent<T>();
			Objects[i].gameObject.SetActive (false);
			Objects[i].transform.parent = parentObject;
		}
		CurrentIndex = 0;
	}

	public void Reset()
	{
		for (int i = 0; i < Capacity; i++)
		{
			Objects[i].gameObject.SetActive(false);
		}
	}

	public T Get()
	{
		int read = 0;
		while (Objects[CurrentIndex].gameObject.activeSelf && read < Capacity)
		{
			read++;
			CurrentIndex++;
			CurrentIndex %= Capacity;
		}
		if (read >= Capacity)
		{
			// Pool mal dimensionné
			Debug.Log("Pool mal dimensionné!");
			return (GameObject.Instantiate(Model).GetComponent<T>());
		}
		else
		{
			return (Objects[CurrentIndex]);
		}
	}
}
