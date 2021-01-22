using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12.0f;

    void Update()
    {
        // Get coordinates of 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate
        Vector3 move = (transform.right * x) + (transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);
    }
}
