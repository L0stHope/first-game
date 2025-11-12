using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject hits;
    public int highscore;

    private void Update()
    {
        highscore = timer.GetComponent<Timer>().seconds + 60 * timer.GetComponent<Timer>().minutes + hits.GetComponent<PlayerAttackJump>().hits;
        if(highscore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }
}
