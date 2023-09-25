using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    private int killCount, finalTimerVal;

    [SerializeField]
    float HP;

    [SerializeField]
    Image HPDisplay;

    float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        startHealth = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            killCount = GetComponent<CharacterScore>().GetKillCount();
            finalTimerVal = FindObjectOfType<Timer>().GetTimerValue();
            ScenesManager.finalScore = killCount * finalTimerVal;
            Time.timeScale = 0f;
            ScenesManager.LoadGameOverScreen();
        }
    }

    public void TakeDamage(float amt)
    {
        HP -= amt;
        HPDisplay.transform.localScale = Vector3.one * HP / startHealth;
        Debug.Log(HP);
    }
}
