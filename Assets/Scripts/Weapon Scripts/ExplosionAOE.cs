using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAOE : MonoBehaviour
{
    [SerializeField]
    float radius, damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0f);

        foreach (RaycastHit2D hit in hits)
        {
            EnemyBehaviour enemy = hit.transform.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject);

    }
}
