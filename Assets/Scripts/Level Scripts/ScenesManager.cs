using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("current scene: " + currentScene.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadMainMenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadHighScoreScreen()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        if (currentScene < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(currentScene + 1);
        else
            LoadHighScoreScreen();
    }
}
