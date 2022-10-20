using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class joueur : MonoBehaviour{
    public GameManager GameManager;
    private int score = 0;

    public GameObject ballePrefab;
    public Transform pointDepart;

    private float LastActionTime = 0f;
    public float period = 5f;

    private AudioSource audio;

    private void Start(){
        audio = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("player/" + PlayerPrefs.GetString("playerskin","player_red"));
    }

    private void Update(){
        if (Input.GetMouseButton(0)){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, -4.215f, 0);
            if (Time.time - LastActionTime >= period){
                Instantiate(ballePrefab, pointDepart.position, transform.rotation);
                LastActionTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Ball"){
            audio.Play();
            PlayerPrefs.SetInt("level", 1);
            SceneManager.LoadScene(0);
        }
    }
}
