using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public UI ui;
    public Player player;
    public bool firstStart = true;
    public GameObject panelStart;
    private int sceneCountInBildSettings;
    private AudioSource backGround;



    private void Start()
    {
        if (firstStart)
        {
            panelStart.gameObject.SetActive(true);
        }
        firstStart = false;

        backGround = GetComponent<AudioSource>();
    }

    public void OnPlayerDie()
    {
        player.gameObject.SetActive(false);
        ui.ShowUIPanelLose();
        backGround.Stop();
    }

    public void OnPlayerWin()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) //почему то не отрабатывает SceneManager.sceneCount
        {
            player.gameObject.SetActive(false);
            ui.ShowUIPanelGamePassed();
            backGround.Stop();
            return;
        }
        
        player.gameObject.SetActive(false);
        ui.ShowUIPanelWin();
        backGround.Stop();
    }
}
