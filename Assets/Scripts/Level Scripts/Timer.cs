using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    [SerializeField]
    float l1time, l2time, l3time, l4time, l5time;

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
        return secondsCount == l1time ||
            secondsCount == l2time ||
            secondsCount == l3time ||
            secondsCount == l4time ||
            secondsCount == l5time;
    }

    public int GetTimerValue()
    { return secondsCount; }
}
