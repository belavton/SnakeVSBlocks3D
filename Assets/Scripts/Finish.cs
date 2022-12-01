using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private SceneControl sceneControl;
    private CanvasControl canvasControl;

    private void Awake()
    {
        canvasControl = FindObjectOfType(typeof(CanvasControl)) as CanvasControl;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SnakeMovement player))
        {
            Debug.Log("You Won!");
            canvasControl.WinGame();
        }
    }
}
