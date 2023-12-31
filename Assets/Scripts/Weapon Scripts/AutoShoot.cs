using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    Coroutine currentCoroutine;

    [SerializeField]
    Transform bullet;

    [SerializeField]
    float duration, fireInterval;

    [SerializeField]
    Transform offset;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCoroutine == null)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                var closest = enemies[0].transform;
                var distance = (closest.position - transform.position).magnitude;
                foreach (GameObject enemy in enemies)
                {
                    var curDist = (enemy.transform.position - transform.position).magnitude;
                    if (curDist < distance)
                    {
                        distance = curDist;
                        closest = enemy.transform;
                    }
                }
                var direction = (closest.position - transform.position).normalized;
                transform.right = direction;
                currentCoroutine = StartCoroutine(DoShoot(direction));
            }
        }

    }

    IEnumerator DoShoot(Vector2 dir)
    {
        var newBullet = Instantiate(bullet, offset.position, Quaternion.identity);
        newBullet.right = dir;
        yield return new WaitForSeconds(fireInterval);
        currentCoroutine = null;
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
