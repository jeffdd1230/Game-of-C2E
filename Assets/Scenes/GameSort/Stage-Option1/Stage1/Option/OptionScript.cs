using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class OptionScript : MonoBehaviour
{
    public bool Selected;
    public bool InRightPosition;
    public static Vector2 RightPosition_1;
    public static Vector2 RightPosition_2;
    public static Vector2 RightPosition_3;
    public bool Option_Right=true;
    public Vector2 Original;
    // Start is called before the first frame update
    public void Start()
    {
        Original = transform.position;
    }

    public void Re()
    {
        transform.position = Original;
        InRightPosition = false;
    }
    // Update is called once per frame
    public void Update()
    {
        Vector2 RightPosition_1 = new Vector2(119.5f, 327.5f);
        Vector2 RightPosition_2 = new Vector2(119.5f, 258.2f);
        Vector2 RightPosition_3 = new Vector2(119.5f, 180.2f);

        Vector2 Original_1 = new Vector2();
        if (StageData.ModeCheck == 2 || StageData_Hard.ModeCheck == 2)
        {
            RightPosition_3 = Vector2.zero;
        }
        
        if (Vector2.Distance(transform.position, RightPosition_1) < 20.5f)
        {
            //確認有沒有被選擇到
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    if (StageLoad.Stagetype == 1)
                    {
                        if (this.gameObject.name == "Option1")
                        {
                            GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom1(0);
                        }
                        if (this.gameObject.name == "Option2")
                        {
                            GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom2(0);
                        }
                        if (this.gameObject.name == "Option3")
                        {
                            GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom3(0);
                        }
                        if (this.gameObject.name == "Option4")
                        {
                            GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom4(0);
                        }
                        if (this.gameObject.name == "Option5")
                        {
                            GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom5(0);
                        }
                        if (this.gameObject.name == "Option6")
                        {
                            GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom6(0);
                        }
                    }
                    transform.position = RightPosition_1;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
        if (Vector2.Distance(transform.position, RightPosition_2) < 20.5f)
        {
            //確認有沒有被選擇到
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    if (this.gameObject.name == "Option1")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom1(1);
                    }
                    if (this.gameObject.name == "Option2")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom2(1);
                    }
                    if (this.gameObject.name == "Option3")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom3(1);
                    }
                    if (this.gameObject.name == "Option4")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom4(1);
                    }
                    if (this.gameObject.name == "Option5")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom5(1);
                    }
                    if (this.gameObject.name == "Option6")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom6(1);
                    }
                    transform.position = RightPosition_2;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
        if (Vector2.Distance(transform.position, RightPosition_3) < 20.5f)
        {
            //確認有沒有被選擇到
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    if (this.gameObject.name == "Option1")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom1(2);
                    }
                    if (this.gameObject.name == "Option2")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom2(2);
                    }
                    if (this.gameObject.name == "Option3")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom3(2);
                    }
                    if (this.gameObject.name == "Option4")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom4(2);
                    }
                    if (this.gameObject.name == "Option5")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom5(2);
                    }
                    if (this.gameObject.name == "Option6")
                    {
                        GameObject.Find("Canvas/GameContent").GetComponent<StageData>().PushButtom6(2);
                    }
                    transform.position = RightPosition_3;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }

}
