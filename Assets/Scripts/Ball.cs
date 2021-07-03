using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float velocity = 30.0f;

    AudioSource audioSource;

    public AudioClip audioGol, audioRacket, audioRebound;

    public int leftScore = 0;
    public int rightScore = 0;

    public Text leftScoreText;
    public Text rightScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocity;

        audioSource = GetComponent<AudioSource>();

        if (leftScoreText != null) leftScoreText.text = leftScore.ToString();
        if (rightScoreText != null) rightScoreText.text = rightScore.ToString();
    }

    void Update() {
        velocity = velocity + 0.1f;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "RacketLeft") {
            int x = 1;
            int y = verticalDirection(transform.position, collision.transform.position);

            Vector2 direction = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direction * velocity;

            audioSource.clip = audioRacket;
            audioSource.Play();
        }

        if (collision.gameObject.name == "RacketRight") {
            int x = -1;
            int y = verticalDirection(transform.position, collision.transform.position);

            Vector2 direction = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direction * velocity;

            audioSource.clip = audioRacket;
            audioSource.Play();
        }

        if (collision.gameObject.name == "Top" || collision.gameObject.name == "Bottom") {
            audioSource.clip = audioRebound;
            audioSource.Play();
        }
    }

    int verticalDirection(Vector2 ballPosition, Vector2 racketPosition) {
        if (ballPosition.y > racketPosition.y) {
            return 1;
        } else if (ballPosition.y < racketPosition.y) {
            return -1;
        }

        return 0;
    }

    public void resetBall(string direction) {
        transform.position = Vector2.zero;

        int scorePlus = leftScore + rightScore > 0 ? leftScore + rightScore : 1;

        velocity = 30 + scorePlus;

        if (direction == "Right") {
            rightScore++;
            rightScoreText.text = rightScore.ToString();

            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocity;
        } else if (direction == "Left") {
            leftScore++;
            leftScoreText.text = leftScore.ToString();

            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
        }

        audioSource.clip = audioGol;
        audioSource.Play();
    }
}
