using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private string leaderboardKey = "gangster_brigade_leaderboard";
    private int count;
    private Transform newRow;

    [SerializeField]
    private Transform highScoreRow;

    // Start is called before the first frame update
    void Start()
    {
        count = 5;
        LootLockerSDKManager.GetScoreList(leaderboardKey, count, 0, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");

                // Instantiate all rows
                for (int i = 0; i < response.items.Length; i++)
                {
                    float newY =  -1 * (i * 65) + 204;
                    Vector2 rowPos = new Vector2(highScoreRow.position.x, newY);
                    newRow = Instantiate(highScoreRow, rowPos, Quaternion.identity, transform);

                    // Placement txt
                    newRow.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
                    // Username txt
                    newRow.GetChild(1).GetComponent<TextMeshProUGUI>().text = response.items[i].metadata.ToString();
                    // Score txt
                    newRow.GetChild(2).GetComponent<TextMeshProUGUI>().text = response.items[i].score.ToString();
                }
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                Debug.Log("failed: " + response.Error);
#pragma warning restore CS0618 // Type or member is obsolete
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
