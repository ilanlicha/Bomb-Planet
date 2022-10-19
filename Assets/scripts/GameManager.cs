using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int actualLevel;
    private int numberOfBalls;
    private int numberOfBallsDestroyed = 0;
    private int score = 0;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        actualLevel = PlayerPrefs.GetInt("level", 1);
        numberOfBalls = 8 + (actualLevel * 2);
    }

    public void BallDestroy(bool addBalls){
        score++;
        PlayerPrefs.SetInt("score", score);
        if (addBalls){
            numberOfBalls+=2;
        }
        numberOfBallsDestroyed++;
        if (numberOfBallsDestroyed == numberOfBalls){
            Win();
        }
    }

    public void Win()
    {
        audio.Play();
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 1) + 1);
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("bestscore",0))
            PlayerPrefs.SetInt("bestscore",PlayerPrefs.GetInt("score"));
        SceneManager.LoadScene(0);
    }
}
