using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject countdown;
    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameObject.GetComponent<GameOver>().isOver && countdown.GetComponent<Countdown>().isPaused == false)
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
