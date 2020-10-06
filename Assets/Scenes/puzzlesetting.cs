using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class puzzlesetting : MonoBehaviour
{
    public static int puzzletype=3;

    public void pushthree()
    {
        puzzletype = 3;
        GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "拼圖數量:3X3";
    }
    public void pushfour()
    {
        puzzletype = 4;
        GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "拼圖數量:4X4";
    }
    public void pushfive()
    {
        puzzletype = 5;
        GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "拼圖數量:5X5";
    }
}
