using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreasePowerup : MonoBehaviour, IStopPowerUp
{
    public IEnumerator StopPowerUp()
    {
        yield return new WaitForSeconds(7);
        StopPowerUpNow();
    }

    public void StopPowerUpNow()
    {
        Debug.Log("Stop speed");
        FindFirstObjectByType<TubeController>().Fast = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BirdFly>())
        {
            TubeController tb = FindFirstObjectByType<TubeController>();
            if (tb.CurrentBoost != null)
            {
                tb.CurrentBoost.GetComponent<IStopPowerUp>().StopPowerUpNow();
            }
            tb.CurrentBoost = gameObject;
            tb.Fast = true;
            StartCoroutine(StopPowerUp());

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
