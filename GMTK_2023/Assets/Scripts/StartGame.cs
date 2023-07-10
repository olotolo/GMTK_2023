using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartGame : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _displayPlatformToggle;
    bool started = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(_startMenu);
        Time.timeScale = 1f;
        _platform.SetActive(_displayPlatformToggle.GetComponent<Toggle>().isOn);
        FindFirstObjectByType<BirdFly>()._gameOver = false;
        FindAnyObjectByType<TubeController>().CreateNewTubes();
    }

    void Start()
    {
        if (Played.played == false)
        {
            Time.timeScale = 0f;
            Played.played = true;
        }
        else
        {
            Destroy(_startMenu);
            Time.timeScale = 1f;
            FindFirstObjectByType<BirdFly>()._gameOver = false;
            FindAnyObjectByType<TubeController>().CreateNewTubes();


        }


    }
    


}
