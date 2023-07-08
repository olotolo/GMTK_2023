using System.Collections;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] GameObject _tube;
    [SerializeField] GameObject _clickObject;

    public float Speed = 1.0f;
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
            Debug.Log("t+1 / 3");
            StartCoroutine(NextTubeSpawn(TimeBetweenTubes + 1f));
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
