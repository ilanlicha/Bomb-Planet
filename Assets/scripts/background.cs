using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{ 
    void Start(){
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("background", "backgrounds/1"));
    }
}
