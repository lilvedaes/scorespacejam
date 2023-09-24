using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPellet : MonoBehaviour
{
    [SerializeField]
    float speed, damage, duration;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.parent)
            rb.velocity = transform.parent.GetComponent<Rigidbody2D>().velocity + (Vector2)(transform.up * speed);
        else
            rb.velocity = transform.up * speed;
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
