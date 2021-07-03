using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip audioGame;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0)) {
            SceneManager.LoadScene("Game");

            audioSource.clip = audioGame;
            audioSource.Play();

            Destroy(transform.gameObject, 1);
        }
    }
}
