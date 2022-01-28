using UnityEngine;
/// <summary>
/// Classe permettant de générer le terrain en utilisant des prefab
/// qui sont instanciés au lancement pour être placés dans des pools.
/// </summary>
public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject[] GroundModels;
    [SerializeField] private int MaxActiveGrounds;
    [SerializeField] private float GroundSize = 20;

    private ObjectPool[] ObjectPools;
	private GameObject[] ActiveGrounds;
    private int NextGroundToCycle;

	private void Awake()
	{
        Debug.Assert(Player != null, gameObject.name + "/Player not set");
        Debug.Assert(GroundModels != null, gameObject.name + "/GroundModels not set");
        Debug.Assert(MaxActiveGrounds != 0, gameObject.name + "/MaxActiveGrounds not set");
        Debug.Assert(GroundSize != 0, gameObject.name + "/GroundSize not set");
    }

    void Start()
    {
        // On remplit les pools d'objet pour éviter d'instancier en cours de jeu
        ObjectPools = new ObjectPool[GroundModels.Length];
        for (int i = 0; i < GroundModels.Length; i++)
		{
			ObjectPools[i] = new ObjectPool(GroundModels[i], MaxActiveGrounds, gameObject.transform);
		}

        // Initialisation des terrains actifs
        ActiveGrounds = new GameObject[MaxActiveGrounds];
        for (int i = 0; i < MaxActiveGrounds; i++)
		{
			ActiveGrounds[i] = ObjectPools[Random.Range(0, GroundModels.Length)].Get();
			ActiveGrounds[i].SetActive(true);
			ActiveGrounds[i].transform.position = GroundSize * i * Vector3.forward;
        }
        NextGroundToCycle = 0;
    }

    void Update()
    {
        // Est-ce que le joueur a complètement dépassé un terrain
        if (Player.position.z >= ActiveGrounds[NextGroundToCycle].transform.position.z + 2 * GroundSize)
		{
            // Dans ce cas on recycle le terrain en cours
            Vector3 currentPosition = ActiveGrounds[NextGroundToCycle].transform.position;
			ActiveGrounds[NextGroundToCycle].SetActive(false);

            // Et on le remplace par un autre terrain en provenance des pools d'objet
			ActiveGrounds[NextGroundToCycle] = ObjectPools[Random.Range(0, GroundModels.Length)].Get();
			ActiveGrounds[NextGroundToCycle].SetActive(true);

            // On le place en bout de ligne
			ActiveGrounds[NextGroundToCycle].transform.position = currentPosition + GroundSize * MaxActiveGrounds * Vector3.forward;

            // On passe au suivant
            NextGroundToCycle++;
            NextGroundToCycle %= MaxActiveGrounds;
        }
    }
}
