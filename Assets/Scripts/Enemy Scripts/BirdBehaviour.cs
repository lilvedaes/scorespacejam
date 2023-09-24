using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : EnemyBehaviour
{
    private float waitTime;
    private Coroutine currentCoroutine;

    [SerializeField]
    private float sidewaysTimeMin, sidewaysTimeMax;
    [SerializeField]
    private float sidewaysDistanceMin, sidewaysDistanceMax;

    // Update is called once per frame
    void Update()
    {
        var direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        // Look at player
        transform.up = direction;

        waitTime = Random.Range(sidewaysTimeMin, sidewaysTimeMax);
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(MoveSideways(waitTime));
    }

    // Every random time, randomize where the bird is going to move sideways
    IEnumerator MoveSideways(float waitTime)
    {
        Vector3 teleportDist = new Vector3(Random.Range(sidewaysDistanceMin, sidewaysDistanceMax), 0, 0);
        transform.position = transform.position + teleportDist;
        yield return new WaitForSeconds(waitTime);
        currentCoroutine = null;
    }
}
