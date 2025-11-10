using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    public TMP_Text timeText;
    public bool isOver = false;

    void Update()
    {
        timeText.text = ("Hi-Score: " + PlayerPrefs.GetInt("HighScore", 0));
        if (player.transform.position.y < -6 || Math.Abs(player.transform.position.x) > 10)
        {
            isOver = true;
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
        if (isOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }
}

