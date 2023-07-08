using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] GameObject _tube;
    [SerializeField] GameObject _clickObject;
    [SerializeField] public List<GameObject> PowerUp;
    public GameObject CurrentBoost;

    public bool Slow = false;
    public bool Fast = false;

    private float _speed = 3;

    public float Speed
    {
        get
        {
            if(Slow == true)
            {
                return _speed / 1.5f;
            }
            if(Fast == true)
            {
                return _speed * 1.5f;
            }
            return _speed;
        }
        set
        {
            if(Slow == true)
            {
                _speed = value * 1.5f;
                return;
            }
            if(Fast == true)
            {
                _speed = value / 1.5f;
                return;
            }
            _speed = value;
        }
    }

    public float TimeBetweenTubes = 3f;
    bool active = true;
    private int _tubesCreated;

    private void Start()
    {
        CreateNewTubes();
        active = true;
    }

    

    //Instanciate Tubes
    public void CreateNewTubes()
    {
        GameObject clickObject = Instantiate(_clickObject, new Vector3(0,0,0), Quaternion.identity);
        clickObject.transform.SetParent(transform, false);
        _tubesCreated++;
        //When the birds height changes the tube spawns with a delay
        //Gives the Player more time to adjust to the change
        if (_tubesCreated % 3 == 0)
        {
            StartCoroutine(NextTubeSpawn(TimeBetweenTubes + 0));
            return;
        }
        StartCoroutine(NextTubeSpawn(TimeBetweenTubes));

    }

    private void OnDestroy()
    {
        active = false;
    }

    private IEnumerator NextTubeSpawn(float time)
    {
        if(active)
        {
            yield return new WaitForSeconds(time);
            Debug.Log("new tube created");

            CreateNewTubes();
        }
        
    }

    
}
