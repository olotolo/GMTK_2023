using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvisibleClickObject : MonoBehaviour, IPointerClickHandler
{
    public GameObject TubeTop { get; set; }
    public GameObject TubeBot { get; set; }
    private TubeController TubeController { get; set; }

    private Rigidbody2D rb;
    private float _y;

    private void Awake()
    {
        TubeController = FindAnyObjectByType<TubeController>();
        TubeBot = transform.GetChild(0).gameObject;
        TubeTop = transform.GetChild(1).gameObject;
    }

    //Tube Top: Y Value Range 10 - 0 (10-3)
    //Tube Bottom: Y Value Range -10 - 0 (-10 - -3)
    private void Start()
    {
        int _tubeTopX = UnityEngine.Random.Range(3, 10);
        TubeTop.transform.position = new Vector3(TubeTop.transform.position.x, _tubeTopX, 0);
        TubeBot.transform.position = new Vector3(TubeBot.transform.position.x, -3 - (11 - _tubeTopX), 0);
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
         //Leftclick Higher, Rightclick Lower
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(!TubeBot.GetComponent<MoveTube>().ReachedMax)
            {
                _y = transform.position.y;
                GetComponent<Rigidbody2D>().AddForce(transform.up * 50);
            }
            
        } 
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(!TubeTop.GetComponent<MoveTube>().ReachedMax)
            {
                _y = transform.position.y;
                GetComponent<Rigidbody2D>().AddForce(transform.up * -50);
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


    private void Update()
    {
        //Destroyed Tubes when they are too far to the left of the screen
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
        
        //Moves the tube
        transform.position += Vector3.left* Time.deltaTime * TubeController.Speed;
        if (transform.position.y >= _y + 1 || transform.position.y <= _y - 1)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            transform.position = new Vector3(transform.position.x, Convert.ToInt32(transform.position.y), transform.position.z);
            Debug.Log(_y - transform.position.y);
            return;
        }
    }

}
