using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnableEvents : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }

    private void Start()
    {
        gameObject.GetComponent<Toggle>().isOn = Played.Events;
    }

    public void Toggle()
    {
        if (Played.Events == false)
        {
            Played.Events = true;

        }
        else
        {
            Played.Events = false;
        }
    }
}
