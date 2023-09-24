using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScore : MonoBehaviour
{
    public TMP_Text killCountText;

    private int killCount;
    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseKillCount()
    {
        killCount += 1;
        killCountText.text = "Kills: " + killCount;
    }
}
