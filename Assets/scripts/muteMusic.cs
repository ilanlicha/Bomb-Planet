using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteMusic : MonoBehaviour
{
    public Image on;
    public Image off;

    public AudioSource music;

    private void Start()
    {
        music = GameObject.Find("music").GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("music", 1) == 1){
            off.enabled = false;
            on.enabled = true;
            music.volume = 0.5f;
        }else if (PlayerPrefs.GetInt("music", 1) == 0){
            off.enabled = true;
            on.enabled = false;
            music.volume = 0f;
        }
    }

    public void Mute(){
        if (PlayerPrefs.GetInt("music", 1) == 1){
            PlayerPrefs.SetInt("music", 0);
            off.enabled = true;
            on.enabled = false;
            music.volume = 0f;
        } else if (PlayerPrefs.GetInt("music", 1) == 0) {
            PlayerPrefs.SetInt("music", 1);
            off.enabled = false;
            on.enabled = true;
            music.volume = 0.5f;
        }
    }
}
