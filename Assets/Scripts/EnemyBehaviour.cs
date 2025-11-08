using UnityEngine;
using Random = UnityEngine.Random;
using Unity.Mathematics;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private GameObject timer;
    private float floatingSpeed;
    private float flyingDirection;
    private float sinMult;
    private bool isSin;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floatingSpeed = (float) (1 * Math.Pow(timer.GetComponent<Timer>().seconds + 60 * timer.GetComponent<Timer>().minutes, 0.4) + 3);
        sinMult = Random.Range(1, 4);
        if (body.position.x > 0)
        {
            flyingDirection = -1;
        }
        else
        {
            flyingDirection = 1;
        }

        int temp = Random.Range(0, 2);
        if (temp == 1)
        {
            isSin = true;
        }
        else
        {
            isSin = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSin)
        {
            body.linearVelocityX = flyingDirection * floatingSpeed;
        }
        else
        {
            body.linearVelocityX = flyingDirection * floatingSpeed;
            body.linearVelocityY = sinMult * math.sin(body.position.x);
        }

        if (Math.Abs(transform.position.x) > 11)
        {
            Destroy(gameObject);
        }
    }
}
