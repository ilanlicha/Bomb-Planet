using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public bool best;
    void Start()
    {
        if (best)
            GetComponent<Text>().text = PlayerPrefs.GetInt("bestscore", 0).ToString();
        else
            GetComponent<Text>().text = PlayerPrefs.GetInt("score", 0).ToString();
    }
}
