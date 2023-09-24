using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TertiaryShoot : MonoBehaviour
{
    private Coroutine currentCoroutine;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    float shootInterval;

    [SerializeField]
    private InputActionReference shoot;

    // Update is called once per frame
    void Update()
    {
        // SHOOT if enough time has passed to fire another bullet and mouse is pressed
        if (currentCoroutine == null && shoot.action.ReadValue<float>() > 0)
            currentCoroutine = StartCoroutine(DoShoot());
    }

    IEnumerator DoShoot()
    {
        // Spawn bullet
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shootInterval);
        currentCoroutine = null;
    }
}
