using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerAttackJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    //[SerializeField] private Rigidbody2D hitbox;
    //[SerializeField] private GameObject bodyTemp;
    private float jumpHeight;
    public int hits;
    private bool hit;
    public TMP_Text timeText;
    

    private void Start()
    {
        hit = false;
        hits = 0;
        jumpHeight = body.GetComponent<PlayerMovement>().jumpHeight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && hit == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
            body.linearVelocityY = jumpHeight;
            //Debug.Log(isInvincible);
            body.GetComponent<PlayerMovement>().doubleJump = 1;
            hits++;
            timeText.text = hits.ToString();
            body.GetComponent<PlayerMovement>().Invincibility();
            StartCoroutine(FreezeFrame());
        }
    }

    private IEnumerator FreezeFrame()
    {
        hit = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
        hit = false;
    }
}
