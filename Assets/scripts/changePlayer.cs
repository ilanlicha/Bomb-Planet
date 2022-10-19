using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayer : MonoBehaviour
{
    public AudioSource audio;

    public void change(){
        audio.Play();
        PlayerPrefs.SetString("playerskin", GetComponent<Image>().sprite.name);
    }
}
