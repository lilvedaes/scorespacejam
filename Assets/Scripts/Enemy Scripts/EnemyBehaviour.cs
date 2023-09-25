using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    protected GameObject player;
    protected CharacterScore playerScore;

    protected GameManager GM;

    [SerializeField]
    protected float speed, scaleFactor;
    
    [SerializeField]
    protected float health, damage;

    protected bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<CharacterScore>();
        transform.localScale *= scaleFactor;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Lowers the health of the enemy on bullet impact
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !isDead) 
        {
            isDead = true;
            playerScore.IncreaseKillCount();
            GM.ChangeEnemyCount(-1);
            Destroy(gameObject); 
        }
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

    public void DestroyAllEnemies()
    {
        GM.ChangeEnemyCount(-1);
        Destroy(gameObject);
    }
}
