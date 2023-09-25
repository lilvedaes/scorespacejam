using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesManager
{
    public static int finalScore;
    public static string playerID;
    public static void LoadMainMenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public static void LoadHighScoreScreen()
    {
        SceneManager.LoadScene("HighScores");
    }

    public static void LoadGameOverScreen()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void LoadNextScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(currentScene + 1);
        else
            LoadHighScoreScreen();
    }
}
