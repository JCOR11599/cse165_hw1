using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Enemy properties
    public float speed = 2.5f;
    public bool mask = false;
    public GameObject maskObject;

    // Track the GameManager
    private GameManager gameManager;

    void Start()
    {
        // Get the gameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (Random.Range(0.0f, 1.0f) > 0.5)
        {
            transform.position = new Vector3(-1.5f, 0.0f, 20.0f);
        }
        else
        {
            transform.position = new Vector3(1.5f, 0.0f, 20.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.position = transform.position + new Vector3(0.0f, 0.0f, -speed * Time.deltaTime);
        }
    }

    // Entering a zone
    void OnTriggerEnter(Collider other)
    {
        // Entered the safezome
        if (other.name == "SafeZone")
        {
            if (!mask)
            {
                gameManager.SendMessage("GameOver");
            }
        }
        // Entered the despawn border
        else
        {
            Destroy(gameObject);
        }
    }

    // Trigger putting a mask on
    void MaskOn()
    {
        mask = true;
        //gameObject.Find("Mask").SetActive(true);
        maskObject.SetActive(true);
    }
}
