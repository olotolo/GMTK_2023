using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveTube : MonoBehaviour
{
    public TubeController TubeController;
    public GameObject EntangledCube;


    private void Start()
    {
        TubeController = FindAnyObjectByType<TubeController>();
    }
    private void Update()
    {
        
    }
}
