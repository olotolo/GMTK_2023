using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayLowestPlatform : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _platform;
    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }

    private void Start()
    {
        gameObject.GetComponent<Toggle>().isOn = Played.displayPlatform;
        Debug.Log(Played.displayPlatform);
        _platform.SetActive(Played.displayPlatform);
    }

    public void Toggle()
    {
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
