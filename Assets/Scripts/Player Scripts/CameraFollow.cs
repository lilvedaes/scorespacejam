using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    float xPadding, yPadding, speed;

    [SerializeField]
    Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var offset = player.position - transform.position;
        var translateDir = Vector2.zero;
        if (offset.x > xPadding)
        {
            translateDir += Vector2.right;
        }
        else if (offset.x < -xPadding)
        {
            translateDir += Vector2.left;
        }

        if (offset.y > yPadding)
        {
            translateDir += Vector2.up;
        }
        else if (offset.y < -yPadding)
        {
            translateDir += Vector2.down;
        }

        transform.Translate(translateDir * speed * Time.deltaTime);
    }
}
