using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Set sensitivity of mouse
    public float mouseSensitivity = 10.0f;

    // Track yaw and pitch
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Get the x and y cursor positions, and scale by sensitivity and deltaTime
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Restrict values
        yaw %= 360.0f;
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

        // Move Camera
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
