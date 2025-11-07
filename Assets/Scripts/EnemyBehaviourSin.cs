using Unity.Mathematics;
using UnityEngine;

public class EnemyBehaviourSin : MonoBehaviour
{
    [SerializeField] private float floatingSpeed;
    private Rigidbody2D body;
    private float flyingDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
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
        body.linearVelocityY = 10 * math.sin(body.position.x);
    }
}
