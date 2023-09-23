using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    Transform player;

    [SerializeField]
    float speed, scaleFactor, health, damage;

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
}
