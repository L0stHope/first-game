using System;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Collections;
using UnityEditor.Timeline;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject timer;
    private float seconds;
    private int cd;
    private bool onCooldown;

    // Update is called once per frame
    void Update()
    {
        seconds =  (float) (3 / (Math.Pow(timer.GetComponent<Timer>().seconds + 60 * timer.GetComponent<Timer>().minutes, 0.4) + 1) + 0.1);
        if (!onCooldown)
        {
            StartCoroutine(Spawn());
        }
        
    }

    private IEnumerator Spawn()
    {
        onCooldown = true;
        float randY = Random.Range(-4, 4);
        int randX = Random.Range(0, 2) * 2 - 1;
        int randEnemy = Random.Range(0, 2);
        GameObject temp = Instantiate(enemy, new Vector2(randX * 10, randY), Quaternion.identity);
        temp.SetActive(true);
        yield return new WaitForSeconds(seconds);
        onCooldown = false;
    }
}
