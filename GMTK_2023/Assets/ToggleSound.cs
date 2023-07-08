using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
        if (Played.muteSound == false)
        {
            Played.muteSound = true;
            FindAnyObjectByType<AudioController>().MuteSound("Tube_1");
        }
        else
        {
            Played.muteSound = false;
            FindAnyObjectByType<AudioController>().EnableSound("Tube_1");
        }
    }

    private void Start()
    {
        GetComponent<Toggle>().isOn = Played.muteSound;
    }
}
