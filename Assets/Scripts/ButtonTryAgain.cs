using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTryAgain : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject Player;

    public void ButtonTryAgainn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
