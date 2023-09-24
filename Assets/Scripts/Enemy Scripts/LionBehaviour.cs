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
    private float chargeWaitTimeMin, chargeWaitTimeMax, stopTime, chargeTime, speedModifier;
    [SerializeField]
    private float damageModifier;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<CharacterScore>();
        transform.localScale *= scaleFactor;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Only update direction if not charging
        if (!charging)
        {
            direction = (player.transform.position - transform.position).normalized;
        }
        transform.Translate(speed * Time.deltaTime * direction);

        waitTime = Random.Range(chargeWaitTimeMin, chargeWaitTimeMax);
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
