using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public TMP_Text timeText;
    private float countdown;
    public bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown = 3.5f;
        Time.timeScale = 0;
        isPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(countdown);
        countdown -= Time.unscaledDeltaTime;
        if (countdown < 0.5)
        {
            Time.timeScale = 1;
            isPaused = false;
            gameObject.SetActive(false);
        }

        timeText.text = countdown.ToString("F0");
    }
}
