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
        NumToBool ntb = new NumToBool();
        gameObject.GetComponent<Toggle>().isOn = ntb.NumberToBool(PlayerPrefs.GetInt("displayPlatform"));
        _platform.SetActive(ntb.NumberToBool(PlayerPrefs.GetInt("displayPlatform")));
    }

    public void Toggle()
    {
        NumToBool ntb = new NumToBool();

        if (ntb.NumberToBool(PlayerPrefs.GetInt("displayPlatform")) == false)
        {
            PlayerPrefs.SetInt("displayPlatform", 1);

        } else
        {
            PlayerPrefs.SetInt("displayPlatform", 0);

        }
        _platform.SetActive(ntb.NumberToBool(PlayerPrefs.GetInt("displayPlatform")));
    }

}
