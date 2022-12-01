using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField]
    private int nextSceneID;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneID, LoadSceneMode.Single);
    }
}
