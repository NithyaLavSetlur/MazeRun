using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook1 : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply vertical rotation (mouse Y)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit the vertical rotation to avoid flipping

        // Apply the rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Camera rotation
        playerBody.Rotate(Vector3.up * mouseX); // Character rotation
    }
}
