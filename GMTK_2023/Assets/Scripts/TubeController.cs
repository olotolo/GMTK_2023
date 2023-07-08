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
    private bool _tubeTimeIncresed;

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
            if(_tubesCreated / 3 == 0 && _tubesCreated != 0)
            {
                TimeBetweenTubes += 3f;
                _tubeTimeIncresed = true;
            }
            StartCoroutine(NextTubeSpawn());
        }
        _tubesCreated++;

    }

    private void OnDestroy()
    {
        active = false;
    }

    private IEnumerator NextTubeSpawn()
    {
        if(active)
        {
            yield return new WaitForSeconds(TimeBetweenTubes);
            if(_tubeTimeIncresed)
            {
                Debug.Log("Tubetime decreased");
                TimeBetweenTubes -= 3f;
                _tubeTimeIncresed = false;
            }
            Debug.Log("new tube created");

            CreateNewTubes();
        }
        
    }

    
}
