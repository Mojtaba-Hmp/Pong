using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private Text scoreText;
    public static int rightPlayerScore;
    public static int leftPlayerScore;
    public GameObject leftPlayerPanelWon;
    public GameObject rightPlayerPanelWon;
    private AudioSource audioSource;
    public AudioClip winSound;
    private bool soundPlayed = false;
    private int winScore = 3;

    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        leftPlayerPanelWon.SetActive(false);
        rightPlayerPanelWon.SetActive(false);
    }
    void Update()
    {
        scoreText.text = leftPlayerScore + " - " + rightPlayerScore;

        if (leftPlayerScore == winScore && !soundPlayed)
        {
            leftPlayerPanelWon.SetActive(true);
            Time.timeScale = 0;
            audioSource.PlayOneShot(winSound);
            soundPlayed = true;
        }

        if (rightPlayerScore == winScore && !soundPlayed)
        {
            rightPlayerPanelWon.SetActive(true);
            Time.timeScale = 0;
            audioSource.PlayOneShot(winSound);
            soundPlayed = true;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
