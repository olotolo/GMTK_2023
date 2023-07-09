using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnablePowerUps : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }



    private void Start()
    {
        NumToBool ntb = new NumToBool();
        gameObject.GetComponent<Toggle>().isOn = ntb.NumberToBool(PlayerPrefs.GetInt("powerUps"));
    }

    public void Toggle()
    {
        NumToBool ntb = new NumToBool();
        if(ntb.NumberToBool(PlayerPrefs.GetInt("powerUps")) == false)
        {
            PlayerPrefs.SetInt("powerUps", 1);

        } else
        {
            PlayerPrefs.SetInt("powerUps", 0);

        }
    }
}
