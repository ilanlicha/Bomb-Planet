using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balle : MonoBehaviour
{
    public float speed = 4f;
    private GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    void Update(){
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Ball")
        {
            life life = collision.gameObject.GetComponent<life>();
            life.hit();
            if (life.points == 0)
            {
                if (life.niveau == 2 || life.niveau == 3)
                    GameManager.GetComponent<GameManager>().BallDestroy(true);
                else
                    GameManager.GetComponent<GameManager>().BallDestroy(false);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "plafond")
            Destroy(gameObject);
    }
}
