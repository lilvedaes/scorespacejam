using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    private ScenesManager scenesManager;

    [SerializeField]
    float HP;

    [SerializeField]
    Image HPDisplay;

    float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        scenesManager = GameObject.FindObjectOfType<ScenesManager>();
        startHealth = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
            scenesManager.LoadGameOverScreen();
        }
    }

    public void TakeDamage(float amt)
    {
        HP -= amt;
        HPDisplay.transform.localScale *= HP / startHealth;
    }
}
