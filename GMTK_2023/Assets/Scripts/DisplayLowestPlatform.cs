using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayLowestPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }

    

    public void Toggle()
    {
        Debug.Log("Toggle");
        if(Played.displayPlatform == false)
        {
            Played.displayPlatform = true;

        } else
        {
            Played.displayPlatform = false;
        }
        _platform.SetActive(Played.displayPlatform);
    }

}
