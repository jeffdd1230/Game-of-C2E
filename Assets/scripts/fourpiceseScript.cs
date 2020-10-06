using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class fourpiceseScript : MonoBehaviour
{
    public Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    public Image image1;
    public static int x = 0;
    public static string[] piecename = new string[16];
    public int num = 0;
    public void Start()
    {
        //GameObject.Find("pieces_0/puzzle") = image1;
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-7.5f, 0f), Random.Range(1f, 3.5f));
        if (StageData.puzzlecheck != 0)
        {
            for (int i = 0; i < 16; i++)
            {
                if (piecename[i] == this.gameObject.name)
                {
                    this.gameObject.transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
        if (StageData.puzzlecheck == 16)
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
