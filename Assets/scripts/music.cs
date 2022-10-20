using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource audio;
    private AudioLowPassFilter filter;

    private static music _instance;

    public static music instance{
        get{
            if (_instance == null){
                _instance = GameObject.FindObjectOfType<music>();

                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake(){
        audio = GetComponent<AudioSource>();
        filter = GetComponent<AudioLowPassFilter>();
        audio.volume = PlayerPrefs.GetFloat("volume", 0.5f);

        if (!audio.isPlaying)
            audio.Play();

        if (_instance == null){
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    private void OnLevelWasLoaded(int level){
        if (level == 0)
            StartCoroutine(ChangeFilter(220000, 1300, 2));
        else if (level == 1)
            StartCoroutine(ChangeFilter(1300, 220000, 2));
    }

    IEnumerator ChangeFilter(float start, float end, float duration){
        float elapsed = 0.0f;
        while (elapsed < duration){
            filter.cutoffFrequency = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        filter.cutoffFrequency = end;
    }
}
