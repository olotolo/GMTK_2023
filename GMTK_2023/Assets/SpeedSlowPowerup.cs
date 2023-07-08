using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSlowPowerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BirdFly>())
        {
            FindFirstObjectByType<TubeController>().Slow = true;
            StartCoroutine(StopSlow());

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator StopSlow()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Stop slow");
        FindFirstObjectByType<TubeController>().Slow = false;
        Destroy(gameObject);

    }
}
