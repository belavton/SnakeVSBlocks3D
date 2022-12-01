using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public SnakeMovement snake;
    private Vector3 offset;
    
    private void Start()
    {
        offset = transform.position - snake.transform.position;
    }
    
    void Update()
    {
        if (snake != null)
            transform.position = snake.transform.position + offset;
            transform.position = new Vector3(128.6f, 15.9f, snake.transform.position.z + 5.0f);
    }
}
