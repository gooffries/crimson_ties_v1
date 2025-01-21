using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Reference to the player's body Transform

    float xRotation = 0f;

    void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Control rotation around the x-axis (look up and down)
        xRotation -= mouseY;

        // Clamp the vertical rotation to prevent over-rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply horizontal rotation to the player's body
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
