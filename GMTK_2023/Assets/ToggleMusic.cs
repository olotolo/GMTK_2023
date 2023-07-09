using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        NumToBool ntb = new NumToBool();
        if(ntb.NumberToBool(PlayerPrefs.GetInt("muteMusic")) == false)
        {
            PlayerPrefs.SetInt("muteMusic", 1);
            FindAnyObjectByType<AudioController>().MuteSound("MainMenu");
        } else
        {
            PlayerPrefs.SetInt("muteMusic", 0);
            FindAnyObjectByType<AudioController>().EnableSound("MainMenu");
        }
    }
    private void Start()
    {
        NumToBool ntb = new NumToBool();
        GetComponent<Toggle>().isOn = ntb.NumberToBool(PlayerPrefs.GetInt("muteMusic"));
        if(ntb.NumberToBool(PlayerPrefs.GetInt("muteMusic")) == true)
        {
            AudioController audioController = FindFirstObjectByType<AudioController>();
            audioController.MuteSound("MainMenu");
        }
    }
}
