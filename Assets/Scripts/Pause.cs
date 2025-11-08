using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameObject.GetComponent<GameOver>().isOver)
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseScreen.SetActive(isPaused);
        }
    }
}
