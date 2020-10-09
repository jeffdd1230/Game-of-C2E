using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOption : MonoBehaviour
{
    public static string sound = "Linda";
    public static string voice= "us";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void speakeroption(int val)
    {
        if (val == 0)
        {
            GameOption.sound = "John";
            GameOption.voice = "us";
            GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "US Male";
        }
        if (val == 1)
        {
            GameOption.sound = "Linda";
            GameOption.voice = "us";
            GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "US Female";
        }
        if (val == 2)
        {
            GameOption.sound = "Harry";
            GameOption.voice = "gb";
            GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "UK Male";
        }
        if (val == 3)
        {
            GameOption.sound = "Alice";
            GameOption.voice = "gb";
            GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "UK Female";
        }
    }
    /*public void UsMan()
    {
        GameOption.sound = "John";
        GameOption.voice = "us";
        GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "目前是美式男聲";
    }
    public void UsWoman()
    {
        GameOption.sound = "Linda";
        GameOption.voice = "us";
        GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "目前是美式女聲";
    }
    public void UkMan()
    {
        GameOption.sound = "Harry";
        GameOption.voice = "gb";
        GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "目前是英式男聲";
    }
    public void UkWoman()
    {
        GameOption.sound = "Alice";
        GameOption.voice = "gb";
        GameObject.Find("Canvas/MainManu/OptionMenu/speakcheck").GetComponent<Text>().text = "目前是英式女聲";
    }*/
}
