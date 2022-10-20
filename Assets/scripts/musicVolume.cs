using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicVolume : MonoBehaviour
{
    public Slider slider;
    private AudioSource audio;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        audio = GameObject.Find("music").GetComponent<AudioSource>();
        slider.onValueChanged.AddListener((v) => { 
            audio.volume = v;
            PlayerPrefs.SetFloat("volume", v);
        });
    }
}
