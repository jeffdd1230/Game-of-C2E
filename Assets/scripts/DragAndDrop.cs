using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class DragAndDrop : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject SelectedPiece;
    
   
    //倒數計時

    public Text time_UI;
    public int x;
    public void Start()
    {
        InvokeRepeating("timer", 1, 1);
    }
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
    public void Update()
    {
        
        //print(piceseScript.x);
        if (piceseScript.x == 9)
        {
            CancelInvoke("timer");
            OpenPanel2();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector3.zero);
            if(hit.transform.CompareTag("Puzzle"))
            {
                if(!hit.transform.GetComponent<piceseScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<piceseScript>().Selected = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectedPiece.GetComponent<piceseScript>().Selected = false;
            SelectedPiece = null;
            
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);

        }
    }
    public void OpenPanel()
    {
        string path = Application.persistentDataPath + "/FinishPuzzle.txt";
        File.AppendAllText(path, "," + Puzzle.x.ToString() );
        piceseScript.x = 0;
        if (StageLoad.Stagetype == 1)
        {
            StageData.puzzlecheck = 0;
            piceseScript.piecename = new string[9];
            Panel.SetActive(true);
            OpenPanel2();
        }
        if (StageLoad.Stagetype == 2)
        {
            StageData_Hard.puzzlecheck = 0;
            piceseScript.piecename = new string[9];
            Panel.SetActive(true);
            OpenPanel2();
        }
        
    }
    public void OpenPanel2()
    {
        Panel2.SetActive(true);
        GameObject.Find("finishpanel").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("original/Pokemon" + Puzzle.x);
        GameObject.Find("finishpanel").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(2.065949f, 1.776987f, 1);
    }
    public void OpenFailure()
    {
        Panel3.SetActive(true);
    }
}
