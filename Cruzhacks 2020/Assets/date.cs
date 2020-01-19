using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class date : MonoBehaviour
{
    public GameObject time;
    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.Find("date");
        Text text = time.GetComponent<Text>();
        DateTime realdate = DateTime.Now;
        text.text = realdate.ToString();
    }

}
