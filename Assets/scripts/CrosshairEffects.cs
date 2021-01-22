using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairEffects : MonoBehaviour
{
    public Image crosshair;
    public Slider slider;

    private RaycastHit hit;
    private GameObject hitObject;
    private float hitTime;

    // Update is called once per frame
    void Update()
    {
        // If hitting something
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            // Hitting Enemy
            if (hit.collider.gameObject.name == "Enemy(Clone)")
            {
                // Change color to red
                crosshair.color = Color.red;

                // Show slider
                slider.gameObject.SetActive(true);
                slider.value = hitTime / 2;
                
                // Hitting same object
                if (hitObject == hit.collider.gameObject)
                {
                    hitTime += Time.deltaTime;
                }
                // Changed targets to enemy or nothing
                else
                {
                    hitObject = hit.collider.gameObject;
                    hitTime = 0.0f;
                }

                // HitTime exceeds 2 seconds, initiate putting on mask
                if (hitTime >= 2.0f)
                {
                    hitObject.SendMessage("MaskOn");
                    hitTime = 0.0f;
                }
            }
            // Hitting the ground
            else
            {
                // Change color to white
                crosshair.color = Color.white;

                // Hide slider
                slider.gameObject.SetActive(false);

                hitTime = 0.0f;
            }
        }
        // Hitting nothing
        else
        {
            // Change color to white
            crosshair.color = Color.white;

            // Hide slider
            slider.gameObject.SetActive(false);

            hitObject = null;
            hitTime = 0.0f;
        }
    }
}
