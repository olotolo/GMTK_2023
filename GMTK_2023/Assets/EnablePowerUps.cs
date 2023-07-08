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
        gameObject.GetComponent<Toggle>().isOn = Played.powerUps;
    }

    public void Toggle()
    {
        Debug.Log("Toggle");
        if(Played.powerUps == false)
        {
            Played.powerUps = true;

        } else
        {
            Played.powerUps = false;
        }
    }
}
