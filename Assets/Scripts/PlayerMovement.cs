using System.Collections;
using UnityEngine;

public class PlayerMoveent : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D body;
    private int facingDirection;
    private int doubleJump;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        //Debug.Log(doubleJump);
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocityY);

        if(Input.GetButtonDown("Jump") && doubleJump != 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpHeight);
            doubleJump--;
        }

        if(Input.GetButtonUp("Jump") && body.linearVelocityY > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpHeight * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            //isGrounded = true;
            doubleJump = 2;
        }
    }

    private IEnumerator Dash()
    {
        if (body.linearVelocityX < 1)
        {
            facingDirection = -1;
        }
        else if (body.linearVelocityX > 1)
        {
            facingDirection = 1;
        }
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
}
