using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    public float movementSpeed;

    [SerializeField]
    private InputActionReference movement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.Translate(movement.action.ReadValue<Vector2>() * movementSpeed * Time.deltaTime);
    }
}
