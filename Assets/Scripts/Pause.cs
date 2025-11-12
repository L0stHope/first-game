using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameObject.GetComponent<GameOver>().isOver)
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseScreen.SetActive(isPaused);
        }
    }

    public void Return()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1;
    }
}
