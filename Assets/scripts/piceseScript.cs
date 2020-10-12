using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class piceseScript : MonoBehaviour
{
    public  Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    public static int x = 0;
    public static string[] piecename = new string[9];
    public int num = 0;
    public void Start()
    {
        //GameObject.Find("pieces_0/puzzle") = image1;
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(11f, 18f), Random.Range(2.5f, -7));
        if (StageLoad.Stagetype == 1 && StageData.puzzlecheck != 0)
        {
            for (int i = 0; i < 9; i++)
            {
                if (piecename[i] == this.gameObject.name)
                {
                    this.gameObject.transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
        if (StageLoad.Stagetype == 2 && StageData_Hard.puzzlecheck != 0)
        {
            for (int i = 0; i < 9; i++)
            {
                if (piecename[i] == this.gameObject.name)
                {
                    this.gameObject.transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
        if (StageLoad.Stagetype == 1 && StageData.puzzlecheck==9)
        {
            GameObject.Find("Canvas/next").SetActive(false);
        }
        if (StageLoad.Stagetype == 2 && StageData_Hard.puzzlecheck == 9)
        {
            GameObject.Find("Canvas/next").SetActive(false);
        }
    }
    
    public void Update()
    {
        //確認目前位置與正確位置距離是否小於0.5
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            //確認有沒有被選擇到
            if (!Selected)
            {               
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    piecename[x] = this.gameObject.name;
                    //print(piecename[x]);
                    x = x + 1;
                    //print("正確" + x); 
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    //Camera.main.GetComponent<DragAndDrop_>().PlacedPieces++;
                }
            }
        }
    }
    
}
