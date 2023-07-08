using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveTube : MonoBehaviour
{
    public TubeController TubeController;
    public GameObject EntangledCube;
    public string EndName;
    public bool ReachedMax = false;


    private void Start()
    {
        TubeController = FindAnyObjectByType<TubeController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == EndName)
        {
            ReachedMax = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == EndName)
        {
            ReachedMax = false;
        }
    }
}
