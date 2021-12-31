using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestartAllTheGame : MonoBehaviour
{
    public void RestartAllTheGame()
    {
        SceneManager.LoadScene(0);
    }
}
