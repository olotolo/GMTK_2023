using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubePowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] _tubesTop = GameObject.FindGameObjectsWithTag("TubeTop");
        GameObject[] _tubesBot = GameObject.FindGameObjectsWithTag("TubeBot");

        foreach(GameObject g in _tubesTop)
        {
            g.transform.position += new Vector3(0, 1, 0);
        }
        foreach(GameObject g in _tubesBot)
        {
            g.transform.position += new Vector3(0, -1, 0);
        }
        Destroy(gameObject);
    }
}
