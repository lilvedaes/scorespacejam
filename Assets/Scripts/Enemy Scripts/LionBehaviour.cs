using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionBehaviour : EnemyBehaviour
{
    private float waitTime;
    private Vector3 direction;
    private Coroutine currentCoroutine;
    private bool charging;

    [SerializeField]
    private float chargeWaitTimeMin, chargeWaitTimeTimeMax, stopTime, chargeTime, speedModifier;
    [SerializeField]
    private int damageModifier;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.localScale *= scaleFactor;
        charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Only update direction if not charging
        if (!charging)
        {
            direction = (player.position - transform.position).normalized;
        }
        transform.Translate(direction * speed * Time.deltaTime);

        waitTime = Random.Range(chargeWaitTimeMin, chargeWaitTimeTimeMax);
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(LionCharge(waitTime));
    }

    // Every random time, charge at the player
    IEnumerator LionCharge(float waitTime)
    {
        // Stop the lion
        var originalSpeed = speed;
        var originalDamage = damage;
        speed = 0;
        yield return new WaitForSeconds(stopTime);

        // Charge at higher speed with higher damage
        charging = true;
        speed = originalSpeed * speedModifier;
        damage = originalDamage * damageModifier;
        yield return new WaitForSeconds(chargeTime);

        // Reset values
        charging = false;
        speed = originalSpeed;
        damage = originalDamage;
        yield return new WaitForSeconds(waitTime);

        currentCoroutine = null;
    }
}
