using UnityEngine;

/// <summary>
/// Classe permettant de gérer un script sous forme de singleton
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Component
{
	private static T mInstance;
	public static T Instance
	{
		get
		{
			if (mInstance == null)
			{
				mInstance = FindObjectOfType<T>();
				if (mInstance == null)
				{
					GameObject gameObject = new GameObject();
					mInstance = gameObject.AddComponent<T>();
				}
			}

			return (mInstance);
		}
	}

	private void Awake()
	{
		mInstance = this as T;
		DontDestroyOnLoad(gameObject);
	}
}
