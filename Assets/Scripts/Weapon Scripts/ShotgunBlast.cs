using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunBlast : MonoBehaviour
{

    [SerializeField]
    float baseSpeed, duration, damage;

    Rigidbody2D rb;

    [SerializeField]
    InputActionReference pointerPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Orientation of bullet
        var mousePosition = Camera.main.ScreenToWorldPoint(pointerPosition.action.ReadValue<Vector2>());
        var direction = (mousePosition - transform.position).normalized;
        transform.up = direction;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, transform.rotation.eulerAngles.z));

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * baseSpeed;
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
