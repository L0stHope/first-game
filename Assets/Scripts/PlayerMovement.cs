using UnityEngine;

public class PlayerMoveent : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D body;
    //private bool isGrounded;
    private int doubleJump;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(doubleJump);
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
}
