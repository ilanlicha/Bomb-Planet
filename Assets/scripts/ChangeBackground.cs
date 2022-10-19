using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public SpriteRenderer background;
    public Sprite newBackground;
    public AudioClip audioMusic;
    public AudioSource audioClick;

    public void changeBackground(){
        audioClick.Play();
        background.sprite = newBackground;
        PlayerPrefs.SetString("background", "backgrounds/" + newBackground.name);

        GameObject.Find("music").GetComponent<AudioSource>().Stop();
        GameObject.Find("music").GetComponent<AudioSource>().clip = audioMusic;
        GameObject.Find("music").GetComponent<AudioSource>().Play();
    }
}
