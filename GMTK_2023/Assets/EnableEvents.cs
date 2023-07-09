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
        NumToBool ntb = new NumToBool();
        gameObject.GetComponent<Toggle>().isOn = ntb.NumberToBool(PlayerPrefs.GetInt("events"));
    }

    public void Toggle()
    {
        NumToBool ntb = new NumToBool();
        if (ntb.NumberToBool(PlayerPrefs.GetInt("events")) == false)
        {
            PlayerPrefs.SetInt("events", 1);

        }
        else
        {
            PlayerPrefs.SetInt("events", 0);
        }
    }
}
