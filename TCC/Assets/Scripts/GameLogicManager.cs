using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogicManager : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public GameObject gameOver;

    public static GameLogicManager instance;

    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void StartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
