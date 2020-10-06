using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class StageDataBackup : MonoBehaviour
{
    public TextAsset data;
    public string[] lineArray;
    string[][] Array;
    //public int q1=1, q2=2;
    public void Start()
    {
        lineArray = data.text.Split("\r"[0]);
        Array = new string[lineArray.Length][];
        for (int i = 0; i < lineArray.Length; i++)
        {
            Array[i] = lineArray[i].Split("="[0]);
        }
        Data();

    }
    public void Update()
    {
        float timer = 0f;
        timer += Time.deltaTime;
        int sec = 0;
        sec = (int)timer;
        GameObject.Find("Canvas/Time/sec").GetComponent<Text>().text = sec.ToString();
    }
    public void Data()
    {
        //問題選擇(目前沒有隨機問題選擇)
        //int x = UnityEngine.Random.Range(0, 10);
        int x = 0;
        string CHQ = Array[x][0];
        string EQ = Array[x][2];
        string Problem = Array[x][16];
        int q1 = 0, q2 = 0;
        //例句的問題選擇
        string[] P = Problem.Split(new char[2] { ';', ' ' }); //選擇挖空的問題導入P陣列
        for (int j = 0; j < 2; j++)
        {
            int i = UnityEngine.Random.Range(0, P.Length - 1);
            //將例句中之問題轉為底線
            string P1 = P[i];
            //確認隨機變數指到的選項有沒有在例句中,並且作替代以及確認選項產生
            if (EQ.Contains(P1))
            {
                
                if (j == 0)
                {
                    q1 = i;
                }
                if (j == 1)
                {
                    q2 = i;
                }
                EQ = EQ.Replace(P1, "____");
            }
            else 
            {
                j = j- 1;
                continue;
            }
        }
        //中英文問題
        GameObject.Find("Canvas/GameContent/ChineseQ/Text").GetComponent<Text>().text = CHQ;
        GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
        //選項全內容
        string Option1= " ";
        string Option2= " ";
        string Option3= " ";
        string Option4= " ";
        string Option5= " ";
        string Option6= " ";
        string Option7= " ";
        string Option8= " ";
        string OP = Array[x][14];
        int q3 = q1 + 1;
        int q4 = q2 + 1;
        //分割字串
        string[] OPP = OP.Split(new char[2] { ';', ' '});
        //從前面42行得到的q1和q2來產生選項
        for(int i = 0; i< OPP.Length; i++)
        {
            if (i == 0)
            {
                int k = UnityEngine.Random.Range(0, 4);
                if (k == 0)
                {
                    Option1 = OPP[q1];
                }
                if (k == 1)
                {
                    Option1 = OPP[q2];
                }
                if (k == 2)
                {
                    Option1 = OPP[q3];
                }
                if (k == 3)
                {
                    Option1 = OPP[q4];
                }
                GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text = Option1;
            }
            if (i == 1)
            {
                int k = UnityEngine.Random.Range(0, 4);
                if (k == 0)
                {
                    Option2 = OPP[q1];
                }
                if (k == 1)
                {
                    Option2 = OPP[q2];
                }
                if (k == 2)
                {
                    Option2 = OPP[q3];
                }
                if (k == 3)
                {
                    Option2 = OPP[q4];
                }
                if (Option2 == Option1)
                {
                    i = i - 1;
                    continue;
                }
                GameObject.Find("Canvas/GameContent/Pool/Option2/Text").GetComponent<Text>().text = Option2;
            }
            if (i == 2)
            {
                int k = UnityEngine.Random.Range(0, 4);
                if (k == 0)
                {
                    Option3 = OPP[q1];
                }
                if (k == 1)
                {
                    Option3 = OPP[q2];
                }
                if (k == 2)
                {
                    Option3 = OPP[q3];
                }
                if (k == 3)
                {
                    Option3 = OPP[q4];
                }
                if (Option3 == Option1|| Option3 == Option2)
                {
                    i = i - 1;
                    continue;
                }
                GameObject.Find("Canvas/GameContent/Pool/Option3/Text").GetComponent<Text>().text = Option3;
            }
            if (i == 3)
            {
                int k = UnityEngine.Random.Range(0, 4);
                if (k == 0)
                {
                    Option4 = OPP[q1];
                }
                if (k == 1)
                {
                    Option4 = OPP[q2];
                }
                if (k == 2)
                {
                    Option4 = OPP[q3];
                }
                if (k == 3)
                {
                    Option4 = OPP[q4];
                }
                if (Option4 == Option1 || Option4 == Option2 || Option4 == Option3)
                {
                    i = i - 1;
                    continue;
                }
                GameObject.Find("Canvas/GameContent/Pool/Option4/Text").GetComponent<Text>().text = Option4;
            }
            if(i == 4)
            {
                break;
            }
        }
        for (int i = 0; i < OPP.Length; i++)
        {
            string check1 = OPP[q1];
            string check2 = OPP[q2];
            string FirstCheck = OPP[i];
            string ans1 = " ";
            string ans2 = " ";
            int answer = 0;
            //確認答案選擇的順序 ans1為第一個答案 ans2為第二個答案
            if (FirstCheck == check1)
            {
                ans1 = check1;
                ans2 = check2;
                break;
            }
            if (FirstCheck == check2)
            {
                ans1 = check2;
                ans2 = check1;
                break;
            }
            print(q1);
            print(q2);
        }
        //將已知q1和q2傳給AnswerCheck
    }
    public void PushButton1()
    {
        //得出按了按鈕1的值
        string button1 = GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text;
        AnswerCheck(button1);
    }
    public void AnswerCheck(string ButtonName)
    {
      
    }
    
}

