using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    public bool isOver = false;

    void Update()
    {
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

