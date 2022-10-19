using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public GameObject nextball;

    public int points = 10;
    public int niveau = 3;
    private int actualLevel;

    public ParticleSystem explosion;
    private Camera cam;

    private AudioSource audioSource;

    void Start(){
        GetComponentInChildren<TextMesh>().text = points.ToString();
        actualLevel = PlayerPrefs.GetInt("level", 1);
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    public void hit(){
        points -= 1;
        GetComponentInChildren<TextMesh>().text = points.ToString();
        if (points == 0){
            switch (niveau)
            {
                case 3:
                case 2:
                    GameObject obj1 = Instantiate(nextball, transform.position, Quaternion.identity);
                    GameObject obj2 = Instantiate(nextball, transform.position, Quaternion.identity);
                    GameObject[] objs = { obj1, obj2 };
                    objs[0].GetComponent<ballMovement>().horizontalForce *= -1;

                    foreach (GameObject obj in objs){
                        if (cam.WorldToScreenPoint(transform.position).y <= (cam.pixelHeight/ 2))
                            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
                        else
                            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150));
                        obj1.GetComponent<life>().points = 4 + (actualLevel * 2);
                    }
                    break;
                default:    
                    break;
            }

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponentInChildren<MeshRenderer>().enabled = false;

            Instantiate(explosion, transform.position, transform.rotation);
            audioSource.Play();
            Destroy(gameObject,2f);
        }
    }
}
