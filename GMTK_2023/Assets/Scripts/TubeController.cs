using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] GameObject _tube;
    [SerializeField] GameObject _clickObject;
    [SerializeField] public List<GameObject> PowerUp;
    public GameObject CurrentBoost;

    [SerializeField]
    private bool _slow = false;
    public bool Slow
    {
        get => _slow;
        set
        {
            _slow = value;
            if(_slow) { Fast = false; }
        }
    }
    [SerializeField]
    private bool _fast = false;
    public bool Fast
    {
        get => _fast;
        set
        {
            _fast = value;
            if(_fast) { Slow = false; }
        }
    }

    [SerializeField] private float _speed = 3;

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
        float additionalTime = 0;
        if (Slow) additionalTime += 1;
        if (_tubesCreated % 3 == 0)
        {
                additionalTime += 1;
        }
        
        StartCoroutine(NextTubeSpawn(TimeBetweenTubes + additionalTime));

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
