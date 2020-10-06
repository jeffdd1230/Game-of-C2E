using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class fivepiceseScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    public static int x = 0;
    public static string[] piecename = new string[25];
    public int num = 0;
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-2.5f, 5f), Random.Range(4f, -1.5f));
        if (StageData.puzzlecheck != 0)
        {
            for (int i = 0; i < 25; i++)
            {
                if (piecename[i] == this.gameObject.name)
                {
                    this.gameObject.transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
        if (StageData.puzzlecheck == 25)
        {
            GameObject.Find("Canvas/next").SetActive(false);
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    piecename[x] = this.gameObject.name;
                    x = x + 1;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    //Camera.main.GetComponent<DragAndDrop_>().PlacedPieces++;
                }
            }
        }
    }
}