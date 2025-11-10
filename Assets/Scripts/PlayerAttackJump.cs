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
    public TMP_Text timeText;
    public bool isInvincible;

    private void Start()
    {
        hits = 0;
        jumpHeight = body.GetComponent<PlayerMovement>().jumpHeight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            body.linearVelocityY = jumpHeight;
            //Debug.Log(isInvincible);
            body.GetComponent<PlayerMovement>().doubleJump = 1;
            hits++;
            timeText.text = hits.ToString();
            StartCoroutine(InvincibilityFrames());
        }
    }

    IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.2f);
        isInvincible = false;
        Debug.Log(isInvincible);
    }
}
