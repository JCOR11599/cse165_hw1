using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Track GameObjects on screen
    public GameObject target;
    private float spawnRate = 5.0f;

    // Track score
    public TextMeshProUGUI timerText;
    private float timer;

    // Track is gameOver
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;

    // Spawns enemies
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(target);
            spawnRate *= 0.90f;
        }
    }

    // Wait for some seconds before restarting
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Mark game as active
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);

        // Set up score
        timer = 0.0f;
        timerText.text = "Timer: " + timer;

        // Spawn Enemies
        Instantiate(target);
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;
        }
        timerText.text = "Timer: " + timer;
    }

    // Detect Game over
    void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You Survived " + timer + " seconds";

        StartCoroutine(Restart());
    }
}
