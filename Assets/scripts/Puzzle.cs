using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class Puzzle : MonoBehaviour
{
    public string puzzle;
    public string[] lineArray;
    public static int x;
    public int puzzletype;
    // Start is called before the first frame update
    public void Start()
    {
        string puzzlepath = Application.persistentDataPath + "/puzzle.txt";
        puzzle = File.ReadAllText(puzzlepath);
        int k = 1;
        int check = 0;
        
        if(StageLoad.Stagetype == 1)
        {
            puzzletype = StageData.puzzlecheck;
        }
        if (StageLoad.Stagetype == 2)
        {
            puzzletype = StageData_Hard.puzzlecheck;
        }

        x = int.Parse(puzzle);
        for (int i = 1; i <= 9; i++)
        {
            GameObject.Find(i + "/puzzle").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("handle/Pokemon" + x);
            GameObject.Find(i + "/puzzle").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(2.32f, 2.36f, 1);
        }
        for (int i = 1; i <= 9; i++)
        {
            if(StageLoad.Stagetype == 1)
            {
                if (StageData.PuzzleNumber[i - 1] != null)
                {
                    for (int j = 0; j < puzzletype; j++)
                    {
                        if (i == StageData.PuzzleNumber[j])
                        {
                            print("要給的拼圖:" + i);
                            check = 1;
                            break;
                        }
                    }
                }
            }
            if (StageLoad.Stagetype == 2)
            {
                if (StageData_Hard.PuzzleNumber[i - 1] != null)
                {
                    for (int j = 0; j < puzzletype; j++)
                    {
                        if (i == StageData_Hard.PuzzleNumber[j])
                        {
                            print("要給的拼圖:" + i);
                            check = 1;
                            break;
                        }
                    }
                }
            }
            
            if (check == 1)
            {
                check = 0;
                continue;
            }
            else
            {
                print("隱藏");
                print("目前答題狀態:"+ puzzletype);
                GameObject.Find(i.ToString()).SetActive(false);
                continue;
            }            
        }

    }
}
