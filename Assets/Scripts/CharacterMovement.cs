using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    public float movementSpeed;

    private Vector2 lookDirection;

    [SerializeField]
    private InputActionReference movement, shoot, pointerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.Translate(movement.action.ReadValue<Vector2>() * movementSpeed * Time.deltaTime);

        // Orientation
        lookDirection = pointerPosition.action.ReadValue<Vector2>() - (Vector2)Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
