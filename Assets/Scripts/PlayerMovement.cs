using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public float jumpHeight;
    private Rigidbody2D body;
    private int facingDirection;
    public int doubleJump;

    private bool isStunned;
    [SerializeField] private float stunDuration;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f;

    [SerializeField] private GameObject Hitbox;
    private bool canAttack;

    public bool isInvincible;

    void Awake()
    {
        isInvincible = false;
        isStunned = false;
        doubleJump = 2;
        canAttack = true;
        body = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (isDashing || isStunned)
        {
            return;
        }

        if (body.linearVelocityX < 1)
        {
            facingDirection = -1;
        }
        else if (body.linearVelocityX > 1)
        {
            facingDirection = 1;
        }

        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocityY);

        if (Input.GetButtonDown("Jump") && doubleJump != 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpHeight);
            doubleJump--;
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            StartCoroutine(Attack());
            //Debug.Log("test");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            doubleJump = 2;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInvincible && !isStunned && ! isDashing)
        {
            doubleJump = 1;
            //Debug.Log("test");
            StartCoroutine(Stun());     
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.linearVelocity = new Vector2(facingDirection * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator Attack()
    {
        Hitbox.SetActive(true);
        canAttack = false;
        yield return new WaitForSeconds(0.2f);
        Hitbox.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        canAttack = true;
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
        body.linearVelocity = new Vector2(3f * -facingDirection, 3f);
        yield return new WaitForSecondsRealtime(stunDuration);
        isStunned = false;
    }

    public void Invincibility()
    {
        StartCoroutine(InvincibilityFrames());
    }

    public IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.2f);
        isInvincible = false;
    }
}
