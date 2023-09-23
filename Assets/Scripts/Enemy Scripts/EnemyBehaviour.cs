using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    protected Transform player;

    [SerializeField]
    protected float speed, scaleFactor;
    
    [SerializeField]
    protected int health, damage;

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
    }

    // Lowers the health of the enemy on bullet impact
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            //Debug.Log("dealing " + damage + " damage!");
            var player = collision.gameObject.GetComponent<CharacterHealth>();
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
