using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private GroundModel GroundModel;
    [SerializeField] private GroundView GroundView;

    private ObjectPool<Ground>[] GroundsPool;
    private ObjectPool<Ground>[] TransitionsPool;
    private Ground[] ActiveGrounds;
    private int NextGroundToCycle;
    private int NextSpeedBonus;
    private int CurrentSpeedBonus;

	#region Messages Unity

	private void Awake()
	{
        if (null == GroundModel) throw new System.ArgumentNullException("Reference GroundModel is missing!");
        if (null == GroundView) throw new System.ArgumentNullException("Reference GroundView is missing!");
    }

    private void Start()
    {
        Init();
    }

	#endregion

	#region Génération du terrain

    /// <summary>
    /// Initialisation des pools d'objets et du terrain de départ
    /// </summary>
	private void Init()
	{
        // Gestion de l'apparition des boost et transitions
        NextSpeedBonus = GroundModel.BoostStart;
        CurrentSpeedBonus = NextSpeedBonus;

        // On remplit les pools d'objet pour éviter d'instancier en cours de jeu
        GroundsPool = CreatePool(GroundModel.GroundModels, GroundModel.ActiveGrounds, GroundView.transform);
        TransitionsPool = CreatePool(GroundModel.TransitionModels, GroundModel.ActiveGrounds, GroundView.transform);

        // Initialisation des terrains actifs
        float departure = 0.0f;
        ActiveGrounds = new Ground[GroundModel.ActiveGrounds];
        for (int i = 0; i < GroundModel.ActiveGrounds; i++)
        {
            ActiveGrounds[i] = GetNewGround(departure * Vector3.forward, Quaternion.AngleAxis(Random.Range(0, 2) % 2 == 0 ? 0 : 180, Vector3.up));
            departure += ActiveGrounds[i].Length;
        }
        NextGroundToCycle = 0;
    }

    /// <summary>
    /// Création des pools d'objet
    /// </summary>
    /// <param name="models">le gameobject modèle à dupliquer</param>
    /// <param name="maxCapacity">le nombre de copies à intégrer au pool</param>
    /// <param name="parent">le gameobject parent (la view) de chacune des copies</param>
    /// <returns></returns>
    private ObjectPool<Ground>[] CreatePool(Ground[] models, int maxCapacity, Transform parent)
    {
        int tabLength = models.Length;
        ObjectPool<Ground>[] pool = new ObjectPool<Ground>[tabLength];
        for (int i = 0; i < tabLength; i++)
        {
            pool[i] = new ObjectPool<Ground>(models[i].gameObject, maxCapacity, parent);
        }
        return (pool);
    }

    /// <summary>
    /// Création d'une portion de terrain.
    /// En fonction de l'avancement dans le niveau il s'agira d'une transition entre niveau
    /// ou d'une portion classique
    /// </summary>
    /// <returns>la portion de terrain</returns>
    private Ground GetNewGround(Vector3 position, Quaternion rotation)
    {
        Ground newGround;
        // Est-ce que l'on doit générer un speed bonus à l'entrée
        CurrentSpeedBonus--;
        if (CurrentSpeedBonus < 0)
        {
            NextSpeedBonus += GroundModel.BoostStep;
            CurrentSpeedBonus = NextSpeedBonus;
            newGround = TransitionsPool[Random.Range(0, GroundModel.TransitionModels.Length)].Get();
        }
        else
        {
            newGround = GroundsPool[Random.Range(0, GroundModel.GroundModels.Length)].Get();
        }
        newGround.transform.position = position;
        newGround.transform.rotation = rotation;
        newGround.gameObject.SetActive(true);
        newGround.Init();
        return (newGround);
    }

    /// <summary>
    /// Callback lorsque le player se déplace
    /// Cette méthode vérifie si il y a une portion à remplacer par une autre
    /// </summary>
    /// <param name="evt"></param>
    public void OnPlayerPositionChanged(PlayerModel playerModel)
	{
        // Est-ce que le joueur a complètement dépassé un terrain
        if ((null != ActiveGrounds) && (playerModel.Position.z > ActiveGrounds[NextGroundToCycle].transform.position.z + ActiveGrounds[NextGroundToCycle].Length))
        {
            // Dans ce cas on recycle le terrain en cours
            Vector3 currentPosition = ActiveGrounds[NextGroundToCycle].transform.position;
            ActiveGrounds[NextGroundToCycle].gameObject.SetActive(false);

            // Et on le remplace par un autre terrain en provenance des pools d'objet
            ActiveGrounds[NextGroundToCycle] = GetNewGround(currentPosition + ActiveGrounds[NextGroundToCycle].Length * GroundModel.ActiveGrounds * Vector3.forward, Quaternion.AngleAxis(Random.Range(0, 2) % 2 == 0 ? 0 : 180, Vector3.up));

            // On passe au suivant
            NextGroundToCycle++;
            NextGroundToCycle %= GroundModel.ActiveGrounds;
        }
    }

	#endregion
}
