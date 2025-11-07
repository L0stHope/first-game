using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float floatingSpeed;
    private float flyingDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (body.position.x > 0)
        {
            flyingDirection = -1;
        }
        else
        {
            flyingDirection = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocityX = flyingDirection * floatingSpeed;
    }
}
