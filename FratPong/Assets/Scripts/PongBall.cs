
using UnityEngine;

public class PongBall : MonoBehaviour
{
    //the two states of the ball 
    //throwing is when the player can interact
    //in motion is when the ball is moving after the player has interacted
    public enum ballState { throwing, inMotion}


    private ballState pongBallState = ballState.throwing;

    private PongGameManager pongGameManager;

    private Rigidbody rigidbodyBall;

    private Vector2 touchStartPos;

    private bool startedDragOverBall = false;

    private Vector2 prevTouchPos;


    private void Start()
    {
        rigidbodyBall = GetComponent<Rigidbody>();

        
    }

    public void Initialize(PongGameManager pongGameManager)
    {
        this.pongGameManager = pongGameManager;
    }

    private void DestroyBall()
    {
        pongGameManager.NewBallSpawn();
        Destroy(this.gameObject);
        
    }



    private void Update()
    {
        if ((pongBallState == ballState.inMotion && rigidbodyBall.velocity.magnitude < .5f) || transform.position.y < 0)
        {
            DestroyBall();
        }

        if (pongBallState == ballState.throwing && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        startedDragOverBall = true;
                    }
                }

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (startedDragOverBall)
                {
                    Vector3 flickDirection = (touch.position - prevTouchPos);
                    Debug.Log(flickDirection.magnitude);

                    if (flickDirection.magnitude > 50)
                    {
                        rigidbodyBall.AddForce(flickDirection.x/100, 3, flickDirection.magnitude/45, ForceMode.Impulse);
                        rigidbodyBall.useGravity = true;
                        pongBallState = ballState.inMotion;
                    }
                    

                }
                startedDragOverBall = false;
            }
            else
            {
                prevTouchPos = touch.position;
            }
        }
    }

}
