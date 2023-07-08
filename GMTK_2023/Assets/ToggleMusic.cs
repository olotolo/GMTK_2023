using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
        if(Played.muteMusic == false)
        {
            Played.muteMusic = true;
            FindAnyObjectByType<AudioController>().MuteSound("MainMenu");
        } else
        {
            Played.muteMusic = false;
            FindAnyObjectByType<AudioController>().EnableSound("MainMenu");
        }
    }
    private void Start()
    {
        GetComponent<Toggle>().isOn = Played.muteMusic;
    }
}
