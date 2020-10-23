using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class OptionCheck : MonoBehaviour
{
    //答題座標紀錄
   
    public GameObject SelectedOption;
    // Start is called before the first frame update
    public void Start()
    {
        

    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //print(Input.mousePosition);
            print(hit.transform.gameObject.name);
            if (hit.transform.CompareTag("Option"))
            {               
                if (!hit.transform.GetComponent<OptionScript>().InRightPosition)
                {                    
                    SelectedOption = hit.transform.gameObject;
                    SelectedOption.GetComponent<OptionScript>().Selected = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectedOption.GetComponent<OptionScript>().Selected = false;
            SelectedOption = null;
        }
        if (SelectedOption != null)
        {
            Vector2 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedOption.transform.position = new Vector2(MousePoint.x, MousePoint.y);
        }
        

    }
}
