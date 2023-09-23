using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    
    [SerializeField]
    int damage;

    private Rigidbody2D rb;
    private Vector3 mousePosition;
    private Vector2 direction;

    [SerializeField]
    private InputActionReference pointerPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Orientation of bullet
        mousePosition = Camera.main.ScreenToWorldPoint(pointerPosition.action.ReadValue<Vector2>());
        direction = (mousePosition - transform.position).normalized;
        transform.up = direction;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    // Delete the bullet once it is off screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
