using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class StageOption : MonoBehaviour
{
    public static string level = "Easy";
    public static string num = "Puzzle:3X3";
    //public static int val;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = level;
        GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = num;
    }

    // Update is called once per frame
    void Update()
    {
        //Stagetype追本溯源
    }
    public void Stageoption(int val)
    {
        if (val == 0)
        {
            StageLoad.Stagetype = 1;
            GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Easy";
            level = GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text;
            puzzlesetting.puzzletype = 3;
            GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "Puzzle:3X3";
            num = GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text;
        }
        if (val == 1)
        {
            StageLoad.Stagetype = 1;
            GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Easy";
            level = GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text;
            puzzlesetting.puzzletype = 4;
            GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "Puzzle:4X4";
            num = GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text;
        }
        if (val == 2)
        {
            StageLoad.Stagetype = 1;
            GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Easy";
            level = GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text;
            puzzlesetting.puzzletype = 5;
            GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "Puzzle:5X5";
            num = GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text;
        }
        if (val == 3)
        {
            StageLoad.Stagetype = 2;
            GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Hard";
            level = GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text;
            puzzlesetting.puzzletype = 3;
            GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "Puzzle:3X3";
            num = GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text;
        }
        if (val == 4)
        {
            StageLoad.Stagetype = 2;
            GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Hard";
            level = GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text;
            puzzlesetting.puzzletype = 4;
            GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "Puzzle:4X4";
            num = GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text;
        }
        if (val == 5)
        {
            StageLoad.Stagetype = 2;
            GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Hard";
            level = GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text;
            puzzlesetting.puzzletype = 5;
            GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text = "Puzzle:5X5";
            num = GameObject.Find("Canvas/PuzzleSize").GetComponent<Text>().text;
        }
    }
}
