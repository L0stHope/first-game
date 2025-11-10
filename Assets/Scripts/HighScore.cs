using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject hits;
    int highscore;

    private void Update()
    {
        int temp = timer.GetComponent<Timer>().seconds + 60 * timer.GetComponent<Timer>().minutes;
        highscore = temp + hits.GetComponent<PlayerAttackJump>().hits;
        if(highscore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }
}
