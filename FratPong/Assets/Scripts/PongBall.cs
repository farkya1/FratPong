
using UnityEngine;

public class PongBall : MonoBehaviour
{
    [Tooltip("Boolean stating whether the ball can be")]
    [SerializeField] private bool canBallInteract = false;

    private Rigidbody rigidbodyBall;

    private Vector2 touchStartPos;


    private void Start()
    {
        rigidbodyBall = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        if (canBallInteract && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector3 flickDirection = touch.position - touchStartPos;
                rigidbodyBall.AddForce(1, 0, 1, ForceMode.Impulse);
            }
        }
    }

}
