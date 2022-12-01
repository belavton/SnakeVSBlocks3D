using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasControl : MonoBehaviour
{
    public bool IsGameActive { get; private set; }

    [SerializeField]
    private GameObject canvasStart;
    [SerializeField]
    private GameObject canvasLose;
    [SerializeField]
    private GameObject canvasWin;
    [SerializeField]
    private Button startGameButton;
    [SerializeField]
    private Button restartGameButton;
    [SerializeField]
    private Button nextGameButton;
    [SerializeField]
    private TextMeshProUGUI levelCounter;
    [SerializeField]
    private TextMeshProUGUI completedLevelCounter;

    private SceneControl sceneControl;

    private void Awake()
    {
        startGameButton.onClick.AddListener(StartGame);
        restartGameButton.onClick.AddListener(RestartGame);
        nextGameButton.onClick.AddListener(NextGame);
        
        sceneControl = FindObjectOfType(typeof(SceneControl)) as SceneControl;
        levelCounter.text = $"Level {SceneManager.GetActiveScene().buildIndex + 1}";
        completedLevelCounter.text = $"Level {SceneManager.GetActiveScene().buildIndex + 1} Completed!";
    }

    public void LoseGame()
    {
        Lives.SnakeLength = -1;
        IsGameActive = false;
        canvasLose.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        IsGameActive = false;
        canvasWin.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        IsGameActive = true;
        canvasStart.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Lives.SnakeLength = -1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextGame()
    {
        sceneControl.LoadNextScene();


    }
}
