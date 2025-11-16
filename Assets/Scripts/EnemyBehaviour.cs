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
    private bool facingRight;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floatingSpeed = (float) (1 * Math.Pow(timer.GetComponent<Timer>().seconds + 60 * timer.GetComponent<Timer>().minutes, 0.5) + 3);
        sinMult = Random.Range(0, 5);
        if (body.position.x > 0)
        {
            flyingDirection = -1;
        }
        else
        {
            flyingDirection = 1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        //if(Math.Abs(transform.position.x) < 9)
        //{
        //    AudioSource temp = gameObject.GetComponent<AudioSource>();
        //    //temp.pitch = Random.Range(0.5f, 0.9f);
        //    temp.Play();
        //}
        body.linearVelocityX = flyingDirection * floatingSpeed;
        body.linearVelocityY = sinMult * math.sin(body.position.x);

        if (Math.Abs(transform.position.x) > 11)
        {
            Destroy(gameObject);
        }
    }
}
