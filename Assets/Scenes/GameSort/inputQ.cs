using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inputQ : MonoBehaviour
{
    public GameObject input;
    public static string question;
    public void EnterQuestion()
    {
        question = input.GetComponent<Text>().text;
        print(question);
    }
}
