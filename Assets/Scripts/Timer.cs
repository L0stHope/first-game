using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeText;
    private float elapsedTime;
    private bool isRunning = false;
    public int minutes, seconds;

    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            minutes = Mathf.FloorToInt(elapsedTime / 60);
            seconds = Mathf.FloorToInt(elapsedTime % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}