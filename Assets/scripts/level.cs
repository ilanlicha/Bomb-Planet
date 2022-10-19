using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("level", 1).ToString();
    }
}
