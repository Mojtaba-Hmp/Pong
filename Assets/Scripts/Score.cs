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

    private int winScore = 3;

    void Start()
    {
        Time.timeScale = 1;
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        leftPlayerPanelWon.SetActive(false);
        rightPlayerPanelWon.SetActive(false);
        scoreText = gameObject.GetComponent<Text>();
    }

   
    void Update()
    {
        scoreText.text = leftPlayerScore + " - " + rightPlayerScore;

        if (leftPlayerScore == winScore)
        {
            leftPlayerPanelWon.SetActive(true);
            Time.timeScale = 0;
        }

        if (rightPlayerScore == winScore)
        {
            rightPlayerPanelWon.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
