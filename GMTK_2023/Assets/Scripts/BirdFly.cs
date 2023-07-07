using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    [SerializeField] private int _forceUp = 200;
    public float HeightToJump = -0.5f;
    private bool jumped = false;
    private int _score = 0;
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
        }
    }

    private bool _gameOver = false;
    [SerializeField] GameObject _scoreDisplay;
    [SerializeField] GameObject _gameOverScoreDisplay;
    [SerializeField] GameObject _gameOverDisplay;
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
        if (collision.tag == "Tube")
        {
            _gameOverScoreDisplay.GetComponent<TextMeshProUGUI>().text = "Score: " + _score.ToString();

            HeightToJump = -100;
            StartCoroutine(GameOver());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_gameOver == false)
        {
            Score++;
        }
    }


    private IEnumerator GameOver()
    {
        _gameOver = true;
        yield return new WaitForSeconds(1);
        _gameOverDisplay.SetActive(true);
        Debug.Log("Game Over!");
    }
}