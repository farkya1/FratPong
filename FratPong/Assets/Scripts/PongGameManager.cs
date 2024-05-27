
using UnityEngine;

public class PongGameManager : MonoBehaviour
{
    [Tooltip("The score the player must get to for the win")]
    [SerializeField]private int winScore = 5;

    [Tooltip("Location where the ball will be thrown")]
    [SerializeField] private GameObject pongBallSpawnLocation;

    [Tooltip("The gameobject that will spawn the ball")]
    [SerializeField] private GameObject pongBall;

    
}
