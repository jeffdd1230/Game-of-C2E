using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class fourDragAndDrop : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject SelectedPiece;
    public GameObject Panel3;
    public Text time_UI;
    void timer()
    {

        if (StageLoad.Stagetype == 1)
        {
            StageData.puzzle_time -= 1;
            time_UI.text = StageData.puzzle_time + "";
            if (StageData.puzzle_time <= 0)
            {

                time_UI.text = "time up";
                OpenFailure();
                CancelInvoke("timer");
            }
        }
        if (StageLoad.Stagetype == 2)
        {
            StageData_Hard.puzzle_time -= 1;
            time_UI.text = StageData_Hard.puzzle_time + "";
            if (StageData_Hard.puzzle_time <= 0)
            {

                time_UI.text = "time up";
                OpenFailure();
                CancelInvoke("timer");
            }
        }

    }
    void Start()
    {
        InvokeRepeating("timer", 1, 1);
    }
    void Update()
    {
        //print(fourpiceseScript.x);
        if (fourpiceseScript.x == 16)
        {
            CancelInvoke("timer");
            OpenPanel2();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<fourpiceseScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<fourpiceseScript>().Selected = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectedPiece.GetComponent<fourpiceseScript>().Selected = false;
            SelectedPiece = null;

        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
    }
    public void OpenPanel()
    {
        string path = Application.persistentDataPath + "/FinishPuzzle.txt";
        File.AppendAllText(path, ","+fourpuzzle.x.ToString());
        fourpiceseScript.x = 0;
        if (StageLoad.Stagetype == 1)
        {
            StageData.puzzlecheck = 0;
            fourpiceseScript.piecename = new string[16];
            Panel.SetActive(true);
        }
        if (StageLoad.Stagetype == 2)
        {
            StageData_Hard.puzzlecheck = 0;
            fourpiceseScript.piecename = new string[16];
            Panel.SetActive(true);
        }
        
    }
    public void OpenPanel2()
    {
        Panel2.SetActive(true);
        GameObject.Find("finishpanel").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("original/Pokemon" + fourpuzzle.x);
        GameObject.Find("finishpanel").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1.094954f, 0.985961f, 1);
        GameObject.Find("Canvas2/next").SetActive(false);
        fourpiceseScript.x = 0;
        
    }
    public void OpenFailure()
    {
        Panel3.SetActive(true);
    }
}
