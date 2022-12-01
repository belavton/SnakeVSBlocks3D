using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Rigidbody snake;
    private Vector3 previousMousePos;
    public float speed;
    public float sensitivity;
    public Game game;

    private CanvasControl canvasControl;

    private void Start()
    {
        Physics.defaultMaxDepenetrationVelocity = 30000.0f;
    }

    private void Awake()
    {
        canvasControl = FindObjectOfType(typeof(CanvasControl)) as CanvasControl;
    }

    private void FixedUpdate()
    {
       if (canvasControl.IsGameActive)
        {
            Moving(snake);

            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - previousMousePos;
                snake.velocity = new Vector3(delta.x * sensitivity, 0.0f, speed);
            }

            previousMousePos = Input.mousePosition;
        }
    }

    public void Moving(Rigidbody rb)
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void Die()
    {
        canvasControl.LoseGame();
        game.OnPlayerDied();
        snake.velocity = Vector3.zero;
    }
}
