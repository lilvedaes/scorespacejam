using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;

public class SubmitScore : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_Text scoreText;

    private string username;
    private int leaderboardID, score;

    // Start is called before the first frame update
    void Start()
    {
        leaderboardID = 17816;
        score = ScenesManager.finalScore;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call leaderboard API with player data to submit score
    public void SubmitPlayerScore()
    {
        username = usernameInput.text;
        if (username == "")
        {
            var allColors = usernameInput.colors;
            allColors.normalColor = Color.red;
            usernameInput.colors = allColors;
            return;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        LootLockerSDKManager.SubmitScore(ScenesManager.playerID, score, leaderboardID, username, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
#pragma warning restore CS0618 // Type or member is obsolete

        ScenesManager.LoadHighScoreScreen();
    }
}