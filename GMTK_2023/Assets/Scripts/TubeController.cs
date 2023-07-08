using System.Collections;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] GameObject _tube;
    [SerializeField] GameObject _clickObject;

    public float Speed = 1.0f;
    public int TimeBetweenTubes = 3000;
    bool active = true;


    private void Start()
    {
        CreateNewTubes();
    }



    //Instanciate Tubes
    public void CreateNewTubes()
    {
        GameObject clickObject = Instantiate(_clickObject, new Vector3(0,0,0), Quaternion.identity);
        clickObject.transform.SetParent(transform, false);


        if (active)
        {
            StartCoroutine(NextTubeSpawn());
        }
    }

    private void OnDestroy()
    {
        active = false;
    }

    private IEnumerator NextTubeSpawn()
    {
        if(active)
        {
            yield return new WaitForSeconds(3);
            CreateNewTubes();
        }
        
    }

    
}
