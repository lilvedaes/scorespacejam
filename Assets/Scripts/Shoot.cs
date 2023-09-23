using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private Coroutine currentCoroutine;
    private float oldPosX;

    [SerializeField]
    private InputActionReference shoot;

    // Start is called before the first frame update
    void Start()
    {
        oldPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // SHOOT if enough time has passed to fire another bullet and mouse is pressed
        if (currentCoroutine == null && shoot.action.ReadValue<float>() > 0)
        {
            currentCoroutine = StartCoroutine(DoShoot());
        }

        if (oldPosX < transform.position.x)
        {
            // If facing to the right, change shooting point
            shootingPoint.transform.localPosition = new Vector3(0.5f, 0, 0);
            oldPosX = transform.position.x;
        }
        else if (oldPosX > transform.position.x)
        {
            // If facing to the left, change shooting point
            shootingPoint.transform.localPosition = new Vector3(-0.5f, 0, 0);
            oldPosX = transform.position.x;
        }
    }

    IEnumerator DoShoot()
    {
        // Spawn bullet
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        currentCoroutine = null;
    }
}