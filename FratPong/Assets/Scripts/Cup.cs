using UnityEngine;

public class Cup : MonoBehaviour
{
    //the pong cup manager
    private PongCupManager pongCupManager;

    public void SetPongCupManager(PongCupManager pongCupManager)
    {
        this.pongCupManager = pongCupManager;
    }


    private void OnDestroy()
    {
        pongCupManager.subtractCup();
    }

}
