using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
public class fourpuzzle : MonoBehaviour
{
    public string puzzle;
    public string[] lineArray;
    public static int x;

    public void Start()
    {
        string puzzlepath = Application.persistentDataPath + "/puzzle.txt";
        puzzle = File.ReadAllText(puzzlepath);
        int k = 1;
        int check = 0;
        x = int.Parse(puzzle);
        for (int i = 1; i <= 16; i++)
        {
            GameObject.Find(i+"/Puzzle").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("handle/Pokemon" + x);
            GameObject.Find(i+"/Puzzle").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(3.139419f, 3.148902f, 1);
        }
        for (int i = 1; i <= 16; i++)
        {
            if (StageData.PuzzleNumber[i - 1] != null)
            {
                for (int j = 0; j < StageData.puzzlecheck; j++)
                {
                    if (i == StageData.PuzzleNumber[j])
                    {
                        print("要給的拼圖:" + i);
                        check = 1;
                        break;
                    }
                }
            }
            if (check == 1)
            {
                print("不關閉");
                check = 0;
                continue;
            }
            else
            {
                GameObject.Find(i.ToString()).SetActive(false);
                continue;
            }
        }
    }


    
}
