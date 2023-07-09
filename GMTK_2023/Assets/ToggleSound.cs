using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        NumToBool ntb = new NumToBool();
        if (ntb.NumberToBool(PlayerPrefs.GetInt("muteSound")) == false)
        {
            PlayerPrefs.SetInt("muteSound", 1);
            FindAnyObjectByType<AudioController>().MuteSound("Tube_1");
        }
        else
        {
            PlayerPrefs.SetInt("muteSound", 0);
            FindAnyObjectByType<AudioController>().EnableSound("Tube_1");
        }
    }

    private void Start()
    {
        NumToBool ntb = new NumToBool();
        GetComponent<Toggle>().isOn = ntb.NumberToBool(PlayerPrefs.GetInt("muteSound"));
        if(ntb.NumberToBool(PlayerPrefs.GetInt("muteSound")) == true)
        {
            FindAnyObjectByType<AudioController>().MuteSound("Tube_1");
        }
    }
}
