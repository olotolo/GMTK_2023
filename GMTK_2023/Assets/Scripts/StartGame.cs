using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject _startMenu;
    bool started = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(_startMenu);
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Played.played == false)
        {
            Time.timeScale = 0f;
            Played.played = true;
        } else
        {
            Destroy(_startMenu);
            Time.timeScale = 1f;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
