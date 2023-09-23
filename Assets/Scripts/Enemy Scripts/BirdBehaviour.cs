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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.localScale *= scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        waitTime = Random.Range(sidewaysTimeMin, sidewaysTimeMax);
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(MoveSideways(waitTime));
    }

    // Every interval, randomize whether the bird is going to move sideways
    IEnumerator MoveSideways(float waitTime)
    {
        Vector3 teleportDist = new Vector3(Random.Range(sidewaysDistanceMin, sidewaysDistanceMax), (Random.Range(sidewaysDistanceMin, sidewaysDistanceMax)), 0);
        transform.position = transform.position + teleportDist;
        yield return new WaitForSeconds(waitTime);
        currentCoroutine = null;
    }
}
