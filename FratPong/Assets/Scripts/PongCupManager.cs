using AYellowpaper.SerializedCollections;
using UnityEngine;



public class PongCupManager : MonoBehaviour
{
    [Tooltip("the number of cups to the assiciated formations")]
    [SerializeField]
    private SerializedDictionary<int, PongFormationSO[]> dictionaryPongNumToFormation = new SerializedDictionary<int, PongFormationSO[]>();


    [Tooltip("The location that you will spawn the cups")]
    [SerializeField] private Transform cupSpawnLocation;

    [Tooltip("THe pong game manager")]
    [SerializeField] private PongGameManager pongGameManager;

    //the current number of cups left
    private GameObject currSpawnedCup;

    private int numCupsLeft = 10;

    

    

    private void Start()
    {
        SpawnCups(dictionaryPongNumToFormation[10][0].formationGO);
    }

    /// <summary>
    /// spawns the desired cup formation
    /// </summary>
    /// <param name="cupFormation"></param>
    private void SpawnCups(GameObject cupFormation)
    {
        if (currSpawnedCup)
        {
            Destroy(currSpawnedCup);
        }
        currSpawnedCup = Instantiate(cupFormation, cupSpawnLocation.position, Quaternion.identity);

        foreach (Transform child in currSpawnedCup.transform)
        {
            
            Cup cupScript = child.GetComponent<Cup>();

            if (cupScript)
            {
                cupScript.SetPongCupManager(this);
            }
            else
            {
                Debug.LogError("cup dont have cup script");
            }
        }
    }

    public void subtractCup()
    {
        numCupsLeft -= 1;

        if (numCupsLeft == 0)
        {
            pongGameManager.FinalCupHit();
        }
    }


}
