using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class fiveDragAndDrop : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject SelectedPiece;

    public Text time_UI;
    void timer()
    {

        StageData.puzzle_time -= 1;

        time_UI.text = StageData.puzzle_time + "";

        if (StageData.puzzle_time == 0)
        {

            time_UI.text = "time\nup";
            OpenFailure();
            CancelInvoke("timer");
        }

    }
    void Start()
    {
        InvokeRepeating("timer", 1, 1);
    }
    void Update()
    {
        //print(fivepiceseScript.x);
        if (fivepiceseScript.x == 25)
        {
            CancelInvoke("timer");
            OpenPanel2();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
            if(hit.transform.CompareTag("Puzzle"))
            {
                if(!hit.transform.GetComponent<fivepiceseScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<fivepiceseScript>().Selected = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectedPiece.GetComponent<fivepiceseScript>().Selected = false;
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
        File.AppendAllText(path, ","+fivepuzzle.x.ToString());
        fivepiceseScript.x = 0;
        StageData.puzzlecheck = 0;
        fivepiceseScript.piecename = new string[25];
        Panel.SetActive(true);
        OpenPanel2();
    }
    public void OpenPanel2()
    {
        Panel2.SetActive(true);
        GameObject.Find("finishpanel").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("original/Pokemon" + fivepuzzle.x);
        GameObject.Find("finishpanel").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1.176381f, 1.108506f, 1);
    }
    public void OpenFailure()
    {
        Panel3.SetActive(true);
    }
}