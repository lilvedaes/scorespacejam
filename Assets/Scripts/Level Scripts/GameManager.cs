using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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

    public void AdvanceLevel()
    {
        Debug.Log("advance level");
        gameObject.BroadcastMessage("DestroyAllEnemies");
        curLevel++;
    }

    public void ChangeEnemyCount(int num)
    {
        enemyCount += num;
    }
}
