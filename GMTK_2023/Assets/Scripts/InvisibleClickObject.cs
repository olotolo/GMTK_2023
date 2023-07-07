using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvisibleClickObject : MonoBehaviour, IPointerClickHandler
{
    public GameObject TubeTop { get; set; }
    public GameObject TubeBot { get; set; }
    private TubeController TubeController { get; set; }

    private void Awake()
    {
        TubeController = FindAnyObjectByType<TubeController>();
        Debug.Log(transform.childCount);
        TubeBot = transform.GetChild(0).gameObject;
        TubeTop = transform.GetChild(1).gameObject;
    }

    //Tube Top: Y Value Range 10 - 0 (10-3)
    //Tube Bottom: Y Value Range -10 - 0 (-10 - -3)
    private void Start()
    {
        int _tubeTopX = Random.Range(3, 10);
        Debug.Log(_tubeTopX);
        TubeTop.transform.position = new Vector3(TubeTop.transform.position.x, _tubeTopX, 0);



        int _tubeBotX = Random.Range(3+(11-_tubeTopX), 10);
        TubeBot.transform.position = new Vector3(TubeBot.transform.position.x, -3 - (11 - _tubeTopX), 0);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked invis obj");
    //Leftclick Higher, Rightclick Lower
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            TubeTop.transform.position += new Vector3(0, 1, 0);
            TubeBot.transform.position += new Vector3(0, 1, 0);
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            TubeTop.transform.position += new Vector3(0, -1, 0);
            TubeBot.transform.position += new Vector3(0, -1, 0);
        }
    }

    

    private void Update()
    {
        //Moves the tube
        transform.position += Vector3.left * Time.deltaTime * TubeController.Speed;

        //Destroyed Tubes when they are too far to the left of the screen
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
