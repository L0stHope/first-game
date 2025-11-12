using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    public TMP_Text scoreDisplay;
    public TMP_Text highestScore;
    public bool isOver = false;

    void Update()
    {
        scoreDisplay.text = ("Your Score: " + gameObject.GetComponent<HighScore>().highscore);
        highestScore.text = ("Hi-Score: " + PlayerPrefs.GetInt("HighScore", 0));
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

