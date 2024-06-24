using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleMovement : MonoBehaviour
{
    public float speed = 5.0f;  // Speed of the character
    public float verticalSpeed = 3.0f;  // Vertical speed for up/down movement
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        // Get input for horizontal (A/D, Left/Right Arrow) and vertical (W/S, Up/Down Arrow) movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUpDown = 0;

        // Get input for up/down movement (Space/Control or any other keys)
        if (Input.GetKey(KeyCode.Space))
        {
            moveUpDown = 1;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveUpDown = -1;
        }

        // Create a vector for the movement direction
        Vector3 moveDirection = new Vector3(moveHorizontal, moveUpDown * verticalSpeed, moveVertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Move the character
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
