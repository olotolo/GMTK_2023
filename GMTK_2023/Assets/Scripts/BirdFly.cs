using System.Collections;
using TMPro;
using UnityEngine;


public class BirdFly : MonoBehaviour
{
    [SerializeField] private int _forceUp = 200;
    public float HeightToJump = -0.5f;
    private bool jumped = false;
    private int _score = 0, _difficultyCount = 0;
    [SerializeField] GameObject _jumpHeightDisplay;
    [SerializeField] TextMeshProUGUI _highscore;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            if (_scoreDisplay != null)
            {
                _scoreDisplay.GetComponent<TextMeshProUGUI>().text = _score.ToString();
            }
            _difficultyCount++;
            if(_difficultyCount % 3 == 0)
            {
                IncreaseSpeed();
            }
        }
    }

    public bool _gameOver { get; set; }

    private void Awake()
    {
        _gameOver = true;
    }

    private TubeController _tubeController;
    [SerializeField] GameObject _scoreDisplay;
    [SerializeField] GameObject _gameOverScoreDisplay;
    [SerializeField] GameObject _gameOverDisplay;
    [SerializeField] GameObject _jumpDisplay;

    

    private void Start()
    {
        if(PlayerPrefs.GetInt("firstTimePlaying") == 0)
        {
            PlayerPrefs.SetInt("firstTimePlaying", 1);
            PlayerPrefs.SetInt("powerUps", 1);
        }
        NumToBool ntb = new NumToBool();
        _jumpHeightDisplay.SetActive(ntb.NumberToBool(PlayerPrefs.GetInt("displayPlatform")));
        _tubeController = FindAnyObjectByType<TubeController>();
        ChangeJumpDisplay();
    }

    public void Fly()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.AddForce(transform.up * _forceUp);
    }

    private void Update()
    {
        if (transform.position.y < HeightToJump)
        {
            if (jumped == false)
            {
                Fly();
                jumped = true;
            }
        }
        if (transform.position.y > HeightToJump)
        {
            jumped = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TubeTop" || collision.tag == "TubeBot")
        {
            _gameOverScoreDisplay.GetComponent<TextMeshProUGUI>().text = "Score: " + _score.ToString();
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            HeightToJump = -100;
            StartCoroutine(GameOver());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag != "Tubes")
        {
            return;
        }
        if (_gameOver == false)
        {
            Score++;
        }
    }



    private IEnumerator GameOver()
    {
        _gameOver = true;
        if(_score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", _score);
        }
        _highscore.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        yield return new WaitForSeconds(1);
        _gameOverDisplay.SetActive(true);
        Debug.Log("Game Over!");
    }

    public void IncreaseSpeed()
    {
        _tubeController.Speed += 0.1f;
        if(_tubeController.TimeBetweenTubes > 1.501)
        {
            _tubeController.TimeBetweenTubes -= 0.1f;
        }

        ChangeBirdPosition(UnityEngine.Random.Range(HeightToJump - 1.0f, HeightToJump + 1.0f));
        if(HeightToJump > 2.5f) { HeightToJump = 2.5f; }
        else if(HeightToJump < -2.5f) { HeightToJump = -2.5f; }
        ChangeJumpDisplay();
    }

    public void ChangeBirdPosition(float heightToJump)
    {
        HeightToJump = heightToJump;
    }

    private void ChangeJumpDisplay()
    {
        _jumpDisplay.transform.position = new Vector3(_jumpDisplay.transform.position.x, HeightToJump - 0.6f, _jumpDisplay.transform.position.z);
    }

}