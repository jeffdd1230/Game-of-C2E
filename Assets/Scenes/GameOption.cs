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
    public void UsMan()
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
    }
}
