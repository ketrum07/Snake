using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : MonoBehaviour
{
   
    public void buttonNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
