using UnityEngine;
using TMPro;

public class StopwatchTimer : MonoBehaviour
{
    public TMP_Text timeText;     // Reference to a UI Text component
    private float elapsedTime;
    private bool isRunning = false;

    void Start()
    {
        elapsedTime = 0f;
        isRunning = true; // automatically start counting
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            DisplayTime(elapsedTime);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Optional: control functions
    public void StartTimer() => isRunning = true;
    public void StopTimer() => isRunning = false;
    public void ResetTimer()
    {
        elapsedTime = 0f;
        DisplayTime(0f);
    }
}