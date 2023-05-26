using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Summary : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemCount; // Text displaying number of collected gems
    [SerializeField] private TextMeshProUGUI cherryCount; // Text displaying number of collected cherrys
    [SerializeField] private TextMeshProUGUI enemyCount; // Text displaying number of defeated enemys
    [SerializeField] private TextMeshProUGUI timeCount; // Text displaying time
    [SerializeField] private GameObject pauseMenuUI; // Reference to Pause Menu

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            pauseMenuUI.SetActive(true); // Opening summary
            Time.timeScale = 0f; // Stoping game
            gemCount.text = ItemCollector.gems.ToString(); // Setting text to number of collected gems
            cherryCount.text = ItemCollector.cherrys.ToString(); // Setting text to number of collected cherrys
            enemyCount.text = EnemyCount.enemys.ToString(); // Setting text to number of defeated enemys
            timeCount.text = Timer.timer; // Setting text to time at the end of the level
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If escape is pressed...
        {
            Time.timeScale = 1f; // Resuming game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loading next level
        }
    }
}