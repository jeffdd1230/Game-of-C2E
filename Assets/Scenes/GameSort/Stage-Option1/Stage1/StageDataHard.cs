using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class StageDataHard : MonoBehaviour
{
    //倒數計時
    public int time_int = 90;

    public Text time_UI;

    //data導入
    public TextAsset data;
    public string[] lineArray;
    string[][] Array;
    string[] AllOption = new string[8];
    //儲存本題答案
    string[] QuestionAns = new string[3];
    int[] q = new int[3];
    int ModeCheck;
    int x;
    int anscheck = 0;
    int score = 0;
    int times = 0;
    public GameObject Panel;
    public GameObject Panel2;
    public void Start()
    {
        InvokeRepeating("timer", 1, 1);
        lineArray = data.text.Split("\r"[0]);
        Array = new string[lineArray.Length][];
        for (int i = 0; i < lineArray.Length; i++)
        {
            Array[i] = lineArray[i].Split("="[0]);
        }
        Data();
    }
    void timer()
    {

        time_int -= 1;

        time_UI.text = time_int + "";

        if (time_int == 0)
        {

            time_UI.text = "time\nup";
            OpenPanel2();
            CancelInvoke("timer");


        }

    }







    public void Update()
    {
        //float timer = 0f;
        //timer += Time.deltaTime;
        //int sec = 0;
        //sec = (int)timer;

    }





    public void Data()
    {
        //問題選擇(目前沒有隨機問題選擇)
        //題目從2開始
        int x = UnityEngine.Random.Range(2, 200);
        //int x = 19;
        print("目前題目:" + x);
        //int x = 2;
        string CHQ = Array[x][0];
        string EQ = Array[x][2];
        string Problem = Array[x][14];
        int QuestionNum = 0;
        print(EQ);
        //例句的問題選擇
        string OptionCheck = " ";
        string[] Answer; //存入答案
        string[] GetOption;
        //OP存入 T F,F,F ; T F,F,F,F ; T F,F,F,F..
        string OP = Array[x][14];
        OP = OP.TrimEnd(';');
        //OptionGroup 存入 T F,F,F
        string[] OptionGroup = OP.Split(';');
        //print("此選項組總長度:" + OptionGroup.Length);
        string[][] WrongOption;
        WrongOption = new string[OptionGroup.Length][];
        Answer = new string[OptionGroup.Length];
        string[][] Cache;
        Cache = new string[OptionGroup.Length][];
        int num = 0;
        string[] P = new string[Answer.Length];
        for (int i = 0; i < OptionGroup.Length; i++)
        {
            //print("此時i值:" + i);
            //Cache[0] 存入 T ; Cache[1]存入F,F,F
            //print("選項組:"+OptionGroup[i]);
            Cache[i] = OptionGroup[i].Split(" "[0]);
            //print("答案:"+Cache[i][0]);
            //print("錯誤選項:"+Cache[i][1]);
            //Answer 存入 T
            Answer[i] = Cache[i][0];
            string PhCache = Answer[i];
            //print("124行:" + PhCache);
            if (PhCache.Contains("_"))
            {
                string[] Ph = PhCache.Split('_');
                for (int j = 0; j < Ph.Length; j++)
                {
                    string PhTuple = Ph[j];
                    EQ = EQ.Replace(PhTuple, "___");
                }
                Answer[i] = Answer[i].Replace("_", " ");
            }
            //print(Answer[i]);
            P[i] = Answer[i];
            //print("未照順序排的:"+P[i]);
            //將F分開存入二維陣列
            string textcache = Cache[i][1];
            WrongOption[i] = textcache.Split(","[0]);
            // print("錯誤選項第i第0項:"+WrongOption[i][0]);
            //print("錯誤選項第i第1項:" + WrongOption[i][1]);
            //print(WrongOption[i][0]);
        }






        //選擇挖空的問題導入P陣列
        if (P.Length >= 3)
        {
            ModeCheck = 1;
            //選擇要出的問題
            int Q1 = UnityEngine.Random.Range(0, P.Length);
            int Q2 = UnityEngine.Random.Range(0, P.Length);
            int Q3 = UnityEngine.Random.Range(0, P.Length);
            while (Q1 == Q3 || Q1 == Q2 || Q2 == Q3)
            {
                Q1 = UnityEngine.Random.Range(0, P.Length);
                Q2 = UnityEngine.Random.Range(0, P.Length);
                Q3 = UnityEngine.Random.Range(0, P.Length);
            }
            // print(Q1+"和"+Q2+"和"+Q3);
            //將例句中之問題轉為底線
            string P1 = P[Q1];
            string P2 = P[Q2];
            string P3 = P[Q3];
            //確認隨機變數指到的選項有沒有在例句中,並且作替代以及確認選項產生
            //if (EQ.Contains(P1)&&EQ.Contains(P2)&&EQ.Contains(P3))
            // {
            //print("有包含");
            //print(P1);
            //print(P2);
            //print(P3);
            EQ = EQ.Replace(P1, "___");
            EQ = EQ.Replace(P2, "___");
            EQ = EQ.Replace(P3, "___");
            print(EQ);
            if (Q1 < Q2 && Q1 < Q3)
            {
                QuestionAns[0] = P1;
                if (Q2 < Q3)
                {
                    QuestionAns[1] = P2;
                    QuestionAns[2] = P3;
                }
                if (Q3 < Q2)
                {
                    QuestionAns[1] = P3;
                    QuestionAns[2] = P2;
                }
            }
            if (Q2 < Q1 && Q2 < Q3)
            {
                QuestionAns[0] = P2;
                if (Q1 < Q3)
                {
                    QuestionAns[1] = P1;
                    QuestionAns[2] = P3;
                }
                if (Q2 < Q1)
                {
                    QuestionAns[1] = P3;
                    QuestionAns[2] = P1;
                }
            }
            if (Q3 < Q2 && Q3 < Q1)
            {
                QuestionAns[0] = P3;
                if (Q1 < Q2)
                {
                    QuestionAns[1] = P1;
                    QuestionAns[2] = P2;
                }
                if (Q2 < Q1)
                {
                    QuestionAns[1] = P2;
                    QuestionAns[2] = P1;
                }
            }
        }







        if (P.Length < 3)
        {
            ModeCheck = 2;
            int Q1 = UnityEngine.Random.Range(0, P.Length);
            int Q2 = UnityEngine.Random.Range(0, P.Length);
            while (Q1 == Q2)
            {
                Q2 = UnityEngine.Random.Range(0, P.Length);
            }
            //將例句中之問題轉為底線
            string P1 = P[Q1];
            string P2 = P[Q2];
            //確認隨機變數指到的選項有沒有在例句中,並且作替代以及確認選項產生
            EQ = EQ.Replace(P1, "____");
            EQ = EQ.Replace(P2, "____");
            if (Q1 < Q2)
            {
                QuestionAns[0] = P1;
                QuestionAns[1] = P2;
            }
            if (Q2 < Q1)
            {
                QuestionAns[0] = P2;
                QuestionAns[1] = P1;
            }
        }
        else
        {
            print("No Data");
        }
        print("答案:");
        print(QuestionAns[0]);
        print(QuestionAns[1]);
        print(QuestionAns[2]);





        //中英文問題
        GameObject.Find("Canvas/GameContent/ChineseQ/Text").GetComponent<Text>().text = CHQ;
        GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;






        //選項全內容
        string Option1 = " ";
        string Option2 = " ";
        string Option3 = " ";
        string Option4 = " ";
        string Option5 = " ";
        string Option6 = " ";
        string Option7 = " ";
        string Option8 = " ";






        //確認答案順序
        for (int i = 0; i < OptionGroup.Length; i++)
        {
            if (Answer[i] == QuestionAns[0] || Answer[i] == QuestionAns[1] || Answer[i] == QuestionAns[2])
            {
                q[num] = i;
                //print(i);
                //print(q[num]);
                num++;
                continue;
            }
        }
        //確認此題解答數量是否超過2
        if (ModeCheck == 1)
        {
            int ii = 0;
            while (ii < 8)
            {
                int ran1 = UnityEngine.Random.Range(0, 3);
                int ran = q[ran1];
                if (ii < 6 && Answer[ran] == null)
                {
                    continue;
                }
                if (ii == 0 && Answer[ran] != null)
                {
                    AllOption[ii] = Answer[ran];
                    int ran3 = UnityEngine.Random.Range(0, WrongOption[ran].Length);
                    AllOption[ii + 1] = WrongOption[ran][ran3];
                    Answer[ran] = null;
                    WrongOption[ran][ran3] = null;
                    ii += 2;
                    continue;
                }
                if (ii == 2 && Answer[ran] != null)
                {
                    AllOption[ii] = Answer[ran];
                    int ran3 = UnityEngine.Random.Range(0, WrongOption[ran].Length);
                    AllOption[ii + 1] = WrongOption[ran][ran3];
                    Answer[ran] = null;
                    WrongOption[ran][ran3] = null;
                    ii += 2;
                    continue;
                }
                if (ii == 2 && Answer[ran] == null)
                {
                    continue;
                }
                if (ii == 4 && Answer[ran] != null)
                {
                    AllOption[ii] = Answer[ran];
                    int ran3 = UnityEngine.Random.Range(0, WrongOption[ran].Length);
                    AllOption[ii + 1] = WrongOption[ran][ran3];
                    Answer[ran] = null;
                    WrongOption[ran][ran3] = null;
                    ii += 2;
                    continue;
                }
                if (ii == 4 && Answer[ran] == null)
                {
                    continue;
                }
                int ran2 = UnityEngine.Random.Range(0, WrongOption[ran].Length);
                if (ii >= 6 && WrongOption[ran].Length < 3)
                {
                    AllOption[ii] = "test";
                    ii += 1;
                    continue;
                }
                if (ii >= 6 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                if (ii == 6 && WrongOption[ran][ran2] != null)
                {
                    AllOption[ii] = WrongOption[ran][ran2];
                    WrongOption[ran][ran2] = null;
                    ii += 1;
                    continue;
                }
                if (ii == 6 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                if (ii == 7 && WrongOption[ran][ran2] != null)
                {
                    AllOption[ii] = WrongOption[ran][ran2];
                    WrongOption[ran][ran2] = null;
                    ii += 1;
                    break;
                }
                if (ii == 7 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                ii += 1;
            }
            int iii = 0;
            while (iii < 8)
            {
                int xx = UnityEngine.Random.Range(0, 8);
                if (iii == 0 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option1 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    continue;
                }
                if (iii == 1 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option2 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    continue;
                }
                if (iii == 1 && AllOption[xx] == null)
                {
                    continue;
                }
                if (iii == 2 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option3 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    continue;
                }
                if (iii == 2 && AllOption[xx] == null)
                {
                    continue;
                }
                if (iii == 3 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option4 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    continue;
                }
                if (iii == 3 && AllOption[xx] == null)
                {
                    continue;
                }
                if (iii == 4 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option5 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    continue;
                }
                if (iii == 4 && AllOption[xx] == null)
                {
                    continue;
                }
                if (iii == 5 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option6 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    continue;
                }
                if (iii == 5 && AllOption[xx] == null)
                {
                    continue;
                }
                if (iii == 6 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option7 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    continue;
                }
                if (iii == 6 && AllOption[xx] == null)
                {
                    continue;
                }
                if (iii == 7 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option8 = AllOption[xx];
                    AllOption[xx] = null;
                    iii += 1;
                    break;
                }
                if (iii == 7 && AllOption[xx] == null)
                {
                    continue;
                }
                iii += 1;
            }
            GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text = Option1;
            GameObject.Find("Canvas/GameContent/Pool/Option2/Text").GetComponent<Text>().text = Option2;
            GameObject.Find("Canvas/GameContent/Pool/Option3/Text").GetComponent<Text>().text = Option3;
            GameObject.Find("Canvas/GameContent/Pool/Option4/Text").GetComponent<Text>().text = Option4;
            GameObject.Find("Canvas/GameContent/Pool/Option5/Text").GetComponent<Text>().text = Option5;
            GameObject.Find("Canvas/GameContent/Pool/Option6/Text").GetComponent<Text>().text = Option6;
            GameObject.Find("Canvas/GameContent/Pool/Option7/Text").GetComponent<Text>().text = Option7;
            GameObject.Find("Canvas/GameContent/Pool/Option8/Text").GetComponent<Text>().text = Option8;
            times += 10;
        }







        //解答數量小於2
        if (ModeCheck == 2)
        {
            int jj = 0;
            while (jj < 8)
            {
                int ran1 = UnityEngine.Random.Range(0, 2);
                int ran = q[ran1];
                if (jj < 4 && Answer[ran] == null)
                {
                    continue;
                }
                if (jj == 0 && Answer[ran] != null)
                {
                    AllOption[jj] = Answer[ran];
                    int ran3 = UnityEngine.Random.Range(0, WrongOption[ran].Length);
                    AllOption[jj + 1] = WrongOption[ran][ran3];
                    Answer[ran] = null;
                    WrongOption[ran][ran3] = null;
                    jj += 2;
                    continue;
                }
                if (jj == 2 && Answer[ran] != null)
                {
                    AllOption[jj] = Answer[ran];
                    int ran3 = UnityEngine.Random.Range(0, WrongOption[ran].Length);
                    AllOption[jj + 1] = WrongOption[ran][ran3];
                    Answer[ran] = null;
                    WrongOption[ran][ran3] = null;
                    jj += 2;
                    continue;
                }
                if (jj == 2 && Answer[ran] == null)
                {
                    continue;
                }
                int ran2 = UnityEngine.Random.Range(0, WrongOption[ran].Length);
                if (jj >= 4 && WrongOption[ran].Length < 3)
                {
                    AllOption[jj] = "test";
                    jj += 1;
                    continue;
                }
                if (jj >= 4 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                if (jj == 4 && WrongOption[ran][ran2] != null)
                {
                    AllOption[jj] = WrongOption[ran][ran2];
                    WrongOption[ran][ran2] = null;
                    jj += 1;
                    continue;
                }
                if (jj >= 5 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                if (jj == 5 && WrongOption[ran][ran2] != null)
                {
                    AllOption[jj] = WrongOption[ran][ran2];
                    WrongOption[ran][ran2] = null;
                    jj += 1;
                    continue;
                }
                if (jj >= 6 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                if (jj == 6 && WrongOption[ran][ran2] != null)
                {
                    AllOption[jj] = WrongOption[ran][ran2];
                    WrongOption[ran][ran2] = null;
                    jj += 1;
                    continue;
                }
                if (jj == 6 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                if (jj == 7 && WrongOption[ran][ran2] != null)
                {
                    AllOption[jj] = WrongOption[ran][ran2];
                    WrongOption[ran][ran2] = null;
                    jj += 1;
                    break;
                }
                if (jj == 7 && WrongOption[ran][ran2] == null)
                {
                    continue;
                }
                jj += 1;
            }
            int jjj = 0;
            while (jjj < 8)
            {
                int xx = UnityEngine.Random.Range(0, 8);
                if (jjj == 0 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option1 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    continue;
                }
                if (jjj == 1 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option2 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    continue;
                }
                if (jjj == 1 && AllOption[xx] == null)
                {
                    continue;
                }
                if (jjj == 2 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option3 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    continue;
                }
                if (jjj == 2 && AllOption[xx] == null)
                {
                    continue;
                }
                if (jjj == 3 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option4 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    continue;
                }
                if (jjj == 3 && AllOption[xx] == null)
                {
                    continue;
                }
                if (jjj == 4 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option5 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    continue;
                }
                if (jjj == 4 && AllOption[xx] == null)
                {
                    continue;
                }
                if (jjj == 5 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option6 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    continue;
                }
                if (jjj == 5 && AllOption[xx] == null)
                {
                    continue;
                }
                if (jjj == 6 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option7 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    continue;
                }
                if (jjj == 6 && AllOption[xx] == null)
                {
                    continue;
                }
                if (jjj == 7 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_", " ");
                    }
                    Option8 = AllOption[xx];
                    AllOption[xx] = null;
                    jjj += 1;
                    break;
                }
                if (jjj == 7 && AllOption[xx] == null)
                {
                    continue;
                }
                jjj += 1;
            }
            GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text = Option1;
            GameObject.Find("Canvas/GameContent/Pool/Option2/Text").GetComponent<Text>().text = Option2;
            GameObject.Find("Canvas/GameContent/Pool/Option3/Text").GetComponent<Text>().text = Option3;
            GameObject.Find("Canvas/GameContent/Pool/Option4/Text").GetComponent<Text>().text = Option4;
            GameObject.Find("Canvas/GameContent/Pool/Option5/Text").GetComponent<Text>().text = Option5;
            GameObject.Find("Canvas/GameContent/Pool/Option6/Text").GetComponent<Text>().text = Option6;
            GameObject.Find("Canvas/GameContent/Pool/Option7/Text").GetComponent<Text>().text = Option7;
            GameObject.Find("Canvas/GameContent/Pool/Option8/Text").GetComponent<Text>().text = Option8;
            times += 10;
        }
        print("現在模式為:" + ModeCheck);
        print("目前分數:" + score + "目前anscheck:" + anscheck);
    }


    int failcheck = 0;

    //答案選擇及確認
    public void PushButtom1()
    {
        //print(QuestionAns[0]);
        //print(QuestionAns[1]);
        //print(QuestionAns[2]);
        string buttom1 = GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom1 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom1 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom1 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom1 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom1 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom1 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }

    }
    public void PushButtom2()
    {
        string buttom2 = GameObject.Find("Canvas/GameContent/Pool/Option2/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom2 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom2 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom2 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom2 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom2 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom2 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
    }
    public void PushButtom3()
    {
        string buttom3 = GameObject.Find("Canvas/GameContent/Pool/Option3/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom3 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom3 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom3 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom3 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom3 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom3 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
    }
    public void PushButtom4()
    {
        string buttom4 = GameObject.Find("Canvas/GameContent/Pool/Option4/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom4 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom4 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom4 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom4 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom4 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom4 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
    }
    public void PushButtom5()
    {
        string buttom5 = GameObject.Find("Canvas/GameContent/Pool/Option5/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom5 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom5 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom5 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom5 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom5 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom5 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
    }
    public void PushButtom6()
    {
        string buttom6 = GameObject.Find("Canvas/GameContent/Pool/Option6/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom6 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom6 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom6 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom6 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom6 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom6 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
    }
    public void PushButtom7()
    {
        string buttom7 = GameObject.Find("Canvas/GameContent/Pool/Option7/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom7 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom7 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom7 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom7 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom7 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom7 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
    }
    public void PushButtom8()
    {
        string buttom8 = GameObject.Find("Canvas/GameContent/Pool/Option8/Text").GetComponent<Text>().text;
        if (anscheck == 0 && buttom8 == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom8 == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom8 == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 0 && buttom8 != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 1 && buttom8 != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
        if (anscheck == 2 && buttom8 != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            AnswerCheck(anscheck, score);
            return;
        }
    }

    public void AnswerCheck(int value, int ScoreValue)
    {
        print("現在模式為:" + ModeCheck);
        print("目前分數:" + score + "目前anscheck:" + anscheck);
        GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = ScoreValue.ToString();
        if (ModeCheck == 1 && value == 3 && ScoreValue == 300)
        {
            print("答對");
            OpenPanel();
            CancelInvoke("timer");
            return;
        }
        if (ModeCheck == 2 && value == 2 && ScoreValue == 200)
        {
            print("答對");
            OpenPanel();
            CancelInvoke("timer");
            return;
        }
        if (ModeCheck == 1 && value == 3 && ScoreValue <= 300)
        {
            print("失敗");
            OpenPanel2();
            CancelInvoke("timer");
            return;
        }
        if (ModeCheck == 2 && value == 2 && ScoreValue <= 200)
        {
            print("失敗");
            OpenPanel2();
            CancelInvoke("timer");
            return;
        }
    }
    public void Re()
    {
        if (Panel != null)
        {
            anscheck = 0;
            score = 0;
            AnswerCheck(anscheck, score);
            time_int = 30;
            InvokeRepeating("timer", 1, 1);
            Panel2.SetActive(false);
        }
    }



    //過關顯示windows
    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
    //通關失敗
    public void OpenPanel2()
    {
        if (Panel2 != null)
        {
            Panel2.SetActive(true);
        }
    }
}
