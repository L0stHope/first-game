using System.Collections;
using UnityEngine;

public class PlatformDissapear : MonoBehaviour
{
    private float elapsedTime;
    private Renderer rend;
    private bool blinking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elapsedTime = 0f;
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;       
        if(elapsedTime > 5 && blinking == false)
        {
            StartCoroutine(Blink());
        }
        if(elapsedTime > 10)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Blink()
    {
        blinking = true;
        rend.enabled = !rend.enabled;
        yield return new WaitForSeconds(0.2f);
        blinking = false;
    }
}
