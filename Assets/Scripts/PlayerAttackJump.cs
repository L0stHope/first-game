using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    //[SerializeField] private GameObject bodyTemp;
    [SerializeField] private float jumpHeight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            body.linearVelocityY = jumpHeight;
            Debug.Log("Hit");
            body.GetComponent<PlayerMoveent>().doubleJump = 1;
        }
    }
}
