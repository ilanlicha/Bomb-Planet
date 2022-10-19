using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balls = new GameObject[3];
    public Transform[] spawnPoints = new Transform[2];

    private float nextActionTime;
    private float period = 5f;

    private int actualLevel;
    private int numberOfBalls;

    public Text ballsLeftText;

    private void Start(){
        actualLevel = PlayerPrefs.GetInt("level", 1);
        numberOfBalls = 8 + (actualLevel * 2);
        nextActionTime = Time.time;
        ballsLeftText.text = numberOfBalls.ToString();
    }

    void Update(){
        if (Time.time > nextActionTime && numberOfBalls > 0){
            nextActionTime += period;
            Spawn();
            numberOfBalls--;
        }
        ballsLeftText.text = numberOfBalls.ToString();
    }

    void Spawn(){
        GameObject obj = Instantiate(balls[Random.Range(0, 3)], spawnPoints[Random.Range(0, 2)].position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150));
        obj.GetComponent<life>().points = 4 + (actualLevel * 2);
    }
}
