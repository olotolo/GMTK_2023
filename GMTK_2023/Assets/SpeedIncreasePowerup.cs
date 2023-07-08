using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreasePowerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BirdFly>())
        {
            FindFirstObjectByType<TubeController>().Fast = true;
            StartCoroutine(StopBoost());

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator StopBoost()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Stop speed");
        FindFirstObjectByType<TubeController>().Fast = false;
        Destroy(gameObject);

    }
}
