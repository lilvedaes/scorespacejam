using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager GM;

    [SerializeField]
    float minDistanceFromPlayer, spawnBoxSize;

    [SerializeField]
    Transform player;

    Coroutine current;
    // Start is called before the first frame update
    void Start()
    {
        current = null;
        Time.timeScale = 1.0f;
        GM = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current == null)
        {
            //finds a spot on the map that's far from the player
            Vector2 spawnPos = new Vector2(Random.Range(-spawnBoxSize, spawnBoxSize),
                Random.Range(-spawnBoxSize, spawnBoxSize));
            do
                spawnPos = new Vector2(Random.Range(-spawnBoxSize, spawnBoxSize),
                    Random.Range(-spawnBoxSize, spawnBoxSize));
            while (Vector2.Distance(spawnPos, player.position) < minDistanceFromPlayer);

            //selects an enemy from the current level's spawn table
            if (GM.enemyCount < GM.Enemies[GM.curLevel].maxPop)
            {
                current = StartCoroutine(SpawnEnemy(GM.Enemies[GM.curLevel].Spawntable[
                    Random.Range(0, GM.Enemies[GM.curLevel].Spawntable.Length)], spawnPos,
                    GM.Enemies[GM.curLevel].spawnInterval));
            }
        }

    }

    IEnumerator SpawnEnemy(Transform enemy, Vector2 location, float interval)
    {
        // Spawn bullet
        GM.ChangeEnemyCount(1);
        Instantiate(enemy, location, Quaternion.identity, transform);
        yield return new WaitForSeconds(interval);
        current = null;
    }
}
