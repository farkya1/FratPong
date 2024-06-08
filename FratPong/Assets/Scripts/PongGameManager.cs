
using UnityEngine;

public class PongGameManager : MonoBehaviour
{
    [Tooltip("The score the player must get to for the win")]
    [SerializeField] private int winScore = 5;

    [Tooltip("The number of balls the player can throw each turn")]
    [SerializeField] private int ballThrowAmount = 2;

    //the number of balls thrown this turn
    private int currBallThrownAmount = 0;

    [Tooltip("Location where the ball will be thrown")]
    [SerializeField] private Transform pongBallSpawnLocation;

    [Tooltip("The prefab that will spawn the ball")]
    [SerializeField] private GameObject pongBallPrefab;


    //the current pong ball in play
    private GameObject currPongBall;

    private void Start()
    {
        NewBallSpawn();
    }

    public void NewBallSpawn()
    {
     
        GameObject pongBallGO = Instantiate(pongBallPrefab, pongBallSpawnLocation.position, Quaternion.identity);
        PongBall pongBallScript = pongBallGO.GetComponent<PongBall>();
        pongBallScript.Initialize(this);
    }

    public void FinalCupHit()
    {

    }

    
}
