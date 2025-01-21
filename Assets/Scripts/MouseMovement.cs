using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
  public float mouseSensitivity = 100f; // Adjustable sensitivity
  public Transform playerBody;         // Reference to the player's body Transform

  float xRotation = 0f; // Vertical rotation of the camera

  void Start()
  {
    // Lock the cursor and make it invisible
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  void Update()
  {
    // Read mouse input
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    // Debug the inputs (optional)
    Debug.Log($"Mouse X: {mouseX}, Mouse Y: {mouseY}");

    // Handle vertical rotation (look up/down)
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp to prevent over-rotation
    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    // Handle horizontal rotation (look left/right)
    if (playerBody != null)
    {
      playerBody.Rotate(Vector3.up * mouseX);
    }
    else
    {
      Debug.LogWarning("Player Body is not assigned in the Inspector!");
    }
  }
}
