using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnStruct
    {
        public Transform[] Spawntable;
        public float spawnInterval;
        public float maxPop;
    }

    public EnemySpawnStruct[] Enemies;

    public int curLevel
    {
        get; private set;
    }

    public int enemyCount
    {
        get; private set;
    }
    
    [SerializeField]
    GameObject primarySelect, secondarySelect, tertiarySelect;

    [SerializeField]
    GameObject pistol, mg, shotty, rpg, laser, mine, turret;

    [SerializeField]
    Sprite pistolSprite, mgSprite, shottySprite, rpgSprite, laserSprite, mineSprite, turretSprite;

    [SerializeField]
    Image primary, secondary, tertiary;

    [System.Serializable]
    public class Dialog
    {
        public string[] lines;
    }

    public Dialog[] cutscenes;
    int curLine;

    [SerializeField]
    TextMeshProUGUI dialogHolder;

    [SerializeField]
    GameObject dialogBox;

    private void Start()
    {
    
      LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            ScenesManager.playerID = response.player_identifier;
            Debug.Log("successfully started LootLocker session");
        });
        
        primarySelect.SetActive(false);
        secondarySelect.SetActive(false);
        tertiarySelect.SetActive(false);

        secondary.gameObject.SetActive(false);
        tertiary.gameObject.SetActive(false);

        PlaynextDialog();
        dialogBox.SetActive(true);
        
    public void AdvanceLevel()
    {
        Time.timeScale = 0f;
        Debug.Log("advance level");
        gameObject.BroadcastMessage("DestroyAllEnemies");
        dialogBox.SetActive(true);
        curLevel++;
    }

    public void ChangeEnemyCount(int num)
    {
        enemyCount += num;
    }

    public void GrabMG()
    {
        primarySelect.SetActive(false);
        pistol.SetActive(false);
        mg.SetActive(true);
        primary.sprite = mgSprite;
        Time.timeScale = 1;
    }
    public void GrabShotty()
    {
        primarySelect.SetActive(false);
        pistol.SetActive(false);
        shotty.SetActive(true);
        primary.sprite = shottySprite;
        Time.timeScale = 1;
    }
    public void GrabRPG()
    {
        secondarySelect.SetActive(false);
        rpg.SetActive(true);
        secondary.gameObject.SetActive(true);
        secondary.sprite = rpgSprite;
        Time.timeScale = 1;
    }
    public void GrabLaser()
    {
        secondarySelect.SetActive(false);
        laser.SetActive(true);
        secondary.gameObject.SetActive(true);
        secondary.sprite = laserSprite;
        Time.timeScale = 1;
    }
    public void GrabMine()
    {
        tertiarySelect.SetActive(false);
        mine.SetActive(true);
        tertiary.gameObject.SetActive(true);
        tertiary.sprite = mineSprite;
        Time.timeScale = 1;
    }
    public void GrabTurret()
    {
        tertiarySelect.SetActive(false);
        turret.SetActive(true);
        tertiary.gameObject.SetActive(true);
        tertiary.sprite = turretSprite;
        Time.timeScale = 1;
    }

    public void PlaynextDialog()
    {
        Time.timeScale = 0f;
        if(curLine < cutscenes[curLevel].lines.Length)
        {
            dialogHolder.text = cutscenes[curLevel].lines[curLine];
            curLine++;
        }
        else
        {
            curLine = 0;
            dialogBox.SetActive(false);
            switch(curLevel)
            {
                case 1:
                    secondarySelect.gameObject.SetActive(true);
                    break;
                case 2:
                    primarySelect.gameObject.SetActive(true);
                    break;
                case 5:
                    tertiarySelect.gameObject.SetActive(true);
                    break;
                default:
                    Time.timeScale = 1;
                    break;
            }
        }
    }
}
