using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    //[SerializeField] private Rigidbody2D hitbox;
    //[SerializeField] private GameObject bodyTemp;
    private float jumpHeight;


    private void Start()
    {
        jumpHeight = body.GetComponent<PlayerMovement>().jumpHeight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            body.linearVelocityY = jumpHeight;
            Debug.Log("Hit");
            body.GetComponent<PlayerMovement>().doubleJump = 1;
        }
    }
}
