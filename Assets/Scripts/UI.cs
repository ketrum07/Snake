using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text levelNumber;
    public Text scoreText;
    public GameObject panelLose;
    public GameObject panelWin;
    public GameObject panelWinGame;
    private int level;
    public static int score;

    private void Start()
    {
        score = 0;
        level = SceneManager.GetActiveScene().buildIndex + 1;
        levelNumber.text = $"Level " + level.ToString();
    }

    public  void Update() //TODO
    {
        scoreText.text = score.ToString();
    }

    public void ShowUIPanelLose()
    {
        panelLose.gameObject.SetActive(true);
    }

    public void ShowUIPanelWin()
    {
        panelWin.gameObject.SetActive(true);
    }

    public void ShowUIPanelGamePassed()
    {
        panelWinGame.gameObject.SetActive(true);
    }
}
