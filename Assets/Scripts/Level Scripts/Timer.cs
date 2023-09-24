using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    private Coroutine currentCoroutine;
    private int secondsCount;
    private GameManager GM;

    private void Start()
    {
        secondsCount = 0;
        GM = FindObjectOfType<GameManager>();
        currentCoroutine = null;
    }

    void Update()
    {
        if (currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(IncreaseSecond());
        }
    }

    // call this on update
    IEnumerator IncreaseSecond()
    {
        secondsCount++;
        timerText.text = secondsCount.ToString();

        if (isTimeToAdvanceLevel(secondsCount) && GM.curLevel < 5)
        {
            GM.AdvanceLevel();
        }

        yield return new WaitForSeconds(1);
        currentCoroutine = null;
    }

    bool isTimeToAdvanceLevel(int secondsCount)
    {
        return secondsCount == 30 ||
            secondsCount == 60 ||
            secondsCount == 90 ||
            secondsCount == 120 ||
            secondsCount == 150;
    }
}
