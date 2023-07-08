using System;
using System.Collections;
using UnityEngine;

public class InvisibleClickObject : MonoBehaviour
{
    public GameObject TubeTop { get; set; }
    public GameObject TubeBot { get; set; }
    private TubeController TubeController { get; set; }

    private Rigidbody2D rb;
    private float _y;
    private bool _isMoving = false;

    private void Awake()
    {
        TubeController = FindAnyObjectByType<TubeController>();
        TubeBot = transform.GetChild(0).gameObject;
        TubeTop = transform.GetChild(1).gameObject;
    }

    //Tube Top: Y Value Range 10 - 0
    //Tube Bottom: Y Value Range 0 - -10
    private void Start()
    {
        int _tubeTopX = UnityEngine.Random.Range(1, 10);
        TubeTop.transform.position = new Vector3(TubeTop.transform.position.x, _tubeTopX, 0);
        TubeBot.transform.position = new Vector3(TubeBot.transform.position.x, -3 - (11 - _tubeTopX), 0);
        rb = GetComponent<Rigidbody2D>();
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
        if(Input.GetMouseButtonDown(0))
        {
            if(!_isMoving)
            {
                if (!TubeBot.GetComponent<MoveTube>().ReachedMax)
                {
                    if(!FindFirstObjectByType<BirdFly>()._gameOver)
                    {
                        _y = transform.position.y;
                        GetComponent<Rigidbody2D>().AddForce(transform.up * 50);
                        _isMoving = true;
                        FindFirstObjectByType<AudioController>().Play("Tube_1");
                    }
                }
            }
            
        }
        if(Input.GetMouseButtonDown(1))
        {
            if (!_isMoving) {
                if (!TubeTop.GetComponent<MoveTube>().ReachedMax)
                {
                    if (!FindFirstObjectByType<BirdFly>()._gameOver)
                    {
                        _y = transform.position.y;
                        GetComponent<Rigidbody2D>().AddForce(transform.up * -50);
                        _isMoving = true;
                        FindFirstObjectByType<AudioController>().Play("Tube_1");
                    }
                }
            }
        }
        
        //Destroyed Tubes when they are too far to the left of the screen
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
        
        //Moves the tube
        transform.position += Vector3.left* Time.deltaTime * TubeController.Speed;

        //If the position is reached
        if (transform.position.y >= _y + 1 || transform.position.y <= _y -1)
        {
            
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            transform.position = new Vector3(transform.position.x, Convert.ToInt32(transform.position.y), transform.position.z);
            _isMoving = false;
            return;
        }

        
    }


}
