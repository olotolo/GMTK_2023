using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Image;

public class InvisibleClickObject : MonoBehaviour, IPointerClickHandler
{
    public GameObject TubeTop { get; set; }
    public GameObject TubeBot { get; set; }
    private TubeController TubeController { get; set; }

    private Vector3 _destination;

    private Rigidbody2D rb;
    private int change;

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
        TubeTop.transform.position = new Vector3(TubeTop.transform.position.x, _tubeTopX, 0);
        TubeBot.transform.position = new Vector3(TubeBot.transform.position.x, -3 - (11 - _tubeTopX), 0);

        rb = GetComponent<Rigidbody2D>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
         //Leftclick Higher, Rightclick Lower
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(change < 8)
            {
                transform.position += new Vector3(0, 1, 0);
                change++;
            }
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(change > -8)
            {
                transform.position += new Vector3(0, -1, 0);
                change--;
            }
        }
    }

    IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.position = Vector3.Lerp(source, new Vector3(transform.position.x, target.y, transform.position.z), (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, target.y, transform.position.z);
    }
    /*
    IEnumerator moveTube(float y)
    {
        for(int i = 0; i < 5; i++)
        {
            float speed = 20f;
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0,y,0), Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }
    */


    private void Update()
    {
        //Destroyed Tubes when they are too far to the left of the screen
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
        //Moves the tube
        transform.position += Vector3.left * Time.deltaTime * TubeController.Speed;
        rb.MovePosition(transform.position + _destination * Time.deltaTime * 10f);
    }
}
