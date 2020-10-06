using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
public class OtherData : MonoBehaviour
{
    public TextAsset gotdata;
    public string[] Array;
    public int x;
    public static string ch;
    // Start is called before the first frame update
    public void Start()
    {

        GotData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GotData()
    {
        Array = gotdata.text.Split('\r');
        int x = UnityEngine.Random.Range(0, Array.Length);
        ch = Array[x];
        ch = ch.Trim();
        print(x);
        print("7000單:" + ch);
        return ch;
        
    }

}
