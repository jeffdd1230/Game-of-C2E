using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class StageData : MonoBehaviour
{
    //piecenum為確認拿到的拼圖的位置
    //puzzlenum為確認拿到的拼圖種類 目前1-6種
    //puzzlecheck為確認拿到了幾塊拼圖
    //public static int piecenum = 0;
    public static int puzzlenum = 0;
    public static int puzzlecheck = 0;
    //倒數計時
    public int time_int = 90;
    public int Qtime_int = 10;
    //拼圖倒數計時
    public static int puzzle_time = 40;

    public Text time_UI;
    public Text Qtime_UI;
    //選項全內容
    public string Option1 = " ";
    public string Option2 = " ";
    public string Option3 = " ";
    public string Option4 = " ";
    public string Option5 = " ";
    public string Option6 = " ";

    //data導入
    public TextAsset data;
    public TextAsset record;
    public string[] lineArray;
    string[][] Array;
    public static string[] AllOption = new string[6]; //產生選項存放陣列


    //儲存本題答案
    string[] QuestionAns = new string[3];
    int[] q = new int[3];
    //產生確認此題為2ans類型或3ans類型
    int ModeCheck;

    //產生題號
    int x ;

    //產生答案與時間
    int anscheck = 0;
    int score=0;
    int times = 0;

    //產生各種視窗
    public GameObject Panel;   //下一關視窗
    public GameObject Panel2;  //失敗視窗
    public GameObject Panel3;  //獲取全部拼圖視窗
    public GameObject QuestionPanel;


    //產生英文題目與其備份
    string EQ = " ";
    string EQ_Re = " ";

    //產生紀錄用時間以及答題記錄
    public string DateTimeText;
    public string record1;
    public string record2;
    public string record3;
    //存檔路徑
    public string path;
    public string finishpath;
    public string puzzlepath;

    //產生儲存題目語音
    public static string speak;

    //儲存題目正確答案
    public string FinalAnswer;

    //儲存中文題目
    public string CHQ;

    //儲存獲取拼圖序號,初始為3x3拼圖
    public static int[] PuzzleNumber = new int[9];
    public int nn = 0;   //確認puzzle的類別,決定個數



    //計算獲得拼圖數
    public void Start()
    {

        InvokeRepeating("timer", 1, 1);
        lineArray = data.text.Split("\r"[0]);
        Array = new string[lineArray.Length][];
        for (int i = 0; i < lineArray.Length; i++)
        {
            Array[i] = lineArray[i].Split(">"[0]);
        }
        Data();
    }

    //題目計時器
    void timer()
    {

        time_int -= 1;

        time_UI.text = time_int + "";

        if (time_int <= 0)
        {

            time_UI.text = "time up";
            OpenPanel2();
            CancelInvoke("timer");
        }

    }



    //中文題目預覽計時器

    void Qtimer()
    {

        Qtime_int -= 1;

        Qtime_UI.text = Qtime_int + "";

        if (Qtime_int <= 0)
        {

            Qtime_UI.text = "time up";
            CloseQuestionPanel();
            CancelInvoke("Qtimer");
        }

    }
    //答題資料
    public void Data()
    {
        path = Application.persistentDataPath + "/record.txt";
        finishpath = Application.persistentDataPath + "/FinishPuzzle.txt";
        puzzlepath = Application.persistentDataPath + "/puzzle.txt";
        DateTimeText = DateTime.Now.ToString();
        print(DateTimeText);

        if (puzzlecheck == 0)
        {
            if (puzzlesetting.puzzletype == 3)
            {
                PuzzleCheck();
                puzzle_time = 40;
                nn = 9;
            }
            if (puzzlesetting.puzzletype == 4)
            {
                PuzzleCheck();
                puzzle_time = 60;
                nn = 16;
            }
            if (puzzlesetting.puzzletype == 5)
            {
                PuzzleCheck();
                puzzle_time = 90;
                nn = 25;
            }
            PuzzleNumber = new int[nn];
            for (int pp = 0; pp < nn; pp++)
            {
                x = UnityEngine.Random.Range(1, nn + 1);
                for (int j = 0; j < nn; j++)
                {
                    if (PuzzleNumber[j] == null)
                    {
                        break;
                    }
                    while (x == PuzzleNumber[j])
                    {
                        x = UnityEngine.Random.Range(1, nn + 1);
                        j = 0;
                        continue;
                    }

                }
                PuzzleNumber[pp] = x;
                //print("隨機:" + PuzzleNumber[pp]);
            }
        }

        //問題選擇(目前沒有隨機問題選擇)
        //題目從2開始
        x = UnityEngine.Random.Range(1, 300);
        if (x == 113)
        {
            x = UnityEngine.Random.Range(1, 300);
        }


        //Debug用
        if (inputQ.question != null)
        {
            x = int.Parse(inputQ.question)-1;
            inputQ.question = null;
        }
        int DebugNum = x+1;
        print("目前題目:" + DebugNum) ;


        //從data.txt獲取題目
        CHQ = Array[x][0];
        GameObject.Find("Canvas/Question/Q").GetComponent<Text>().text = CHQ;
        print("中文字數:" + CHQ.Length);
        if (CHQ.Length > 20)
        {
            Qtime_int = 5;
            time_int = 95;
            
        }
        InvokeRepeating("Qtimer", 1, 1);

        EQ = Array[x][2];
        FinalAnswer = EQ;
        GameObject.Find("Canvas/GameContent/Debug").GetComponent<Text>().text = EQ;
        GameObject.Find("Canvas/DebugNum").GetComponent<Text>().text = DebugNum.ToString();
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
        string[][] WrongOption;
        WrongOption = new string[OptionGroup.Length][];
        Answer = new string[OptionGroup.Length];
        string[][] Cache;
        Cache = new string[OptionGroup.Length][];
        int num = 0;
        string[] P = new string[Answer.Length];
        for (int i = 0; i < OptionGroup.Length; i++)
        {
            //Cache[0] 存入 T ; Cache[1]存入F,F,F
            Cache[i] = OptionGroup[i].Split(" "[0]);
            //Answer 存入 T
            Answer[i] = Cache[i][0];
            string PhCache = Answer[i];
            //去除片語底線
            if (PhCache.Contains("_"))
            {
                PhCache = PhCache.Replace('_', ' ');
                Answer[i] = PhCache;
            }
            P[i] = Answer[i];
            //將F分開存入二維陣列
            string textcache = Cache[i][1];
            WrongOption[i] = textcache.Split(","[0]);
        }
        





        //選擇挖空的問題導入P陣列
        if (P.Length >= 3)
        {
            ModeCheck = 1;
            //選擇要出的問題(從P中取出3個選項)
            int Q1 = UnityEngine.Random.Range(0, P.Length);
            int Q2 = UnityEngine.Random.Range(0, P.Length);
            int Q3 = UnityEngine.Random.Range(0, P.Length);
            while(Q1 == Q3 || Q1 == Q2 || Q2 == Q3)
            {
                Q1 = UnityEngine.Random.Range(0, P.Length);
                Q2 = UnityEngine.Random.Range(0, P.Length);
                Q3 = UnityEngine.Random.Range(0, P.Length);
            }
            //將例句中之問題轉為底線
            string P1 = P[Q1];
            string P2 = P[Q2];
            string P3 = P[Q3];
            //確認隨機變數指到的選項有沒有在例句中,並且作替代以及確認選項產生
            print(EQ);

            while (Q1 != null && Q2 != null && Q3 != null)
            {
                if (Q1 < Q2 && Q1 < Q3)
                {
                    QuestionAns[0] = P1;
                    if (Q2 < Q3)
                    {
                        QuestionAns[1] = P2;
                        QuestionAns[2] = P3;
                        break;
                    }
                    if (Q3 < Q2)
                    {
                        QuestionAns[1] = P3;
                        QuestionAns[2] = P2;
                        break;
                    }
                }
                if (Q2 < Q1 && Q2 < Q3)
                {
                    QuestionAns[0] = P2;
                    if (Q1 < Q3)
                    {
                        QuestionAns[1] = P1;
                        QuestionAns[2] = P3;
                        break;
                    }
                    if (Q3 < Q1)
                    {
                        QuestionAns[1] = P3;
                        QuestionAns[2] = P1;
                        break;
                    }
                }
                if (Q3 < Q2 && Q3 < Q1)
                {
                    QuestionAns[0] = P3;
                    if (Q1 < Q2)
                    {
                        QuestionAns[1] = P1;
                        QuestionAns[2] = P2;
                        break;
                    }
                    if (Q2 < Q1)
                    {
                        QuestionAns[1] = P2;
                        QuestionAns[2] = P1;
                        break;
                    }
                }
            }
            speak = EQ;
            EQ = EQ.Replace(QuestionAns[0], "1.______");
            EQ = EQ.Replace(QuestionAns[1], "2.______");
            EQ = EQ.Replace(QuestionAns[2], "3.______");
            EQ_Re = EQ;
        }

        
        





        if  (P.Length < 3 )
        {
            ModeCheck = 2;
            int Q1 = UnityEngine.Random.Range(0, P.Length);
            int Q2 = UnityEngine.Random.Range(0, P.Length);
            while (Q1==Q2)
            {
                Q2 = UnityEngine.Random.Range(0, P.Length);
            }
            //將例句中之問題轉為底線
            string P1 = P[Q1];
            string P2 = P[Q2];
            //確認隨機變數指到的選項有沒有在例句中,並且作替代以及確認選項產生
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
            speak = EQ;
            EQ = EQ.Replace(QuestionAns[0], "1.______");
            EQ = EQ.Replace(QuestionAns[1], "2.______");
            EQ_Re = EQ;
        }
        else{
            print("No Data");
        }
        print("答案:");
        print(QuestionAns[0]);
        print(QuestionAns[1]);
        print(QuestionAns[2]);


        //中英文問題
        GameObject.Find("Canvas/GameContent/ChineseQ/Text").GetComponent<Text>().text = CHQ;
        GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
        

        


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
        if (ModeCheck==1)
        {
            int ii = 0;
           while (ii<6)
            {
                int ran1 = UnityEngine.Random.Range(0, 3);
                int ran = q[ran1];
                if(ii<6&& Answer[ran] == null)
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
                ii += 1;
            }
            int iii = 0;
            while (iii < 6)
            {
                int xx = UnityEngine.Random.Range(0, 6);
                if (iii == 0 && AllOption[xx] != null)
                {
                    if (AllOption[xx].Contains("_"))
                    {
                        AllOption[xx] = AllOption[xx].Replace("_"," ");
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
                iii += 1;
            }
            GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text = Option1;
            GameObject.Find("Canvas/GameContent/Pool/Option2/Text").GetComponent<Text>().text = Option2;
            GameObject.Find("Canvas/GameContent/Pool/Option3/Text").GetComponent<Text>().text = Option3;
            GameObject.Find("Canvas/GameContent/Pool/Option4/Text").GetComponent<Text>().text = Option4;
            GameObject.Find("Canvas/GameContent/Pool/Option5/Text").GetComponent<Text>().text = Option5;
            GameObject.Find("Canvas/GameContent/Pool/Option6/Text").GetComponent<Text>().text = Option6;
        }


        //解答數量小於2
        if (ModeCheck==2)
        {
            int jj = 0;
            while (jj < 6)
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
                if (jj>=4&&WrongOption[ran].Length <2)
                {
                    string ch = GameObject.Find("Canvas/GameContent").GetComponent<OtherData>().GotData();
                    //print("替換的單字:"+ch);
                    AllOption[jj] = ch;
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
                jj += 1;
            }
            int jjj = 0;
            while (jjj < 6)
            {
                int xx = UnityEngine.Random.Range(0, 6);
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
                jjj += 1;
            }
            GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text = Option1;
            GameObject.Find("Canvas/GameContent/Pool/Option2/Text").GetComponent<Text>().text = Option2;
            GameObject.Find("Canvas/GameContent/Pool/Option3/Text").GetComponent<Text>().text = Option3;
            GameObject.Find("Canvas/GameContent/Pool/Option4/Text").GetComponent<Text>().text = Option4;
            GameObject.Find("Canvas/GameContent/Pool/Option5/Text").GetComponent<Text>().text = Option5;
            GameObject.Find("Canvas/GameContent/Pool/Option6/Text").GetComponent<Text>().text = Option6;
        }
        //創建紀錄
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "錯誤紀錄:\n");
        }
        if (!File.Exists(finishpath))
        {
            File.WriteAllText(finishpath, "0");
        }
        if (!File.Exists(puzzlepath))
        {
            File.WriteAllText(puzzlepath, "0");
        }
        //顯示目前所得拼圖數
        GameObject.Find("Canvas/Level").GetComponent<Text>().text = "Got " + StageData.puzzlecheck.ToString() + " puzzles";
        //初始設定拼圖塊數以及拼圖時間
        
        GameObject.Find("Canvas/PuzzleTime").GetComponent<Text>().text = "Puzzle Time:"+puzzle_time;
    }

    public void Update()
    {
        
    }
    int failcheck = 0;
    
    //答案選擇及確認
    public void PushButtom1()
    {
        string buttom1 = GameObject.Find("Canvas/GameContent/Pool/Option1/Text").GetComponent<Text>().text;
        GameObject.Find("Canvas/GameContent/Pool/Option1").SetActive(false);
        AnswerCheck(anscheck, score,buttom1);
    }


    public void PushButtom2()
    {
        string buttom2 = GameObject.Find("Canvas/GameContent/Pool/Option2/Text").GetComponent<Text>().text;
        GameObject.Find("Canvas/GameContent/Pool/Option2").SetActive(false);
        AnswerCheck(anscheck, score, buttom2);
    }


    public void PushButtom3()
    {
        string buttom3 = GameObject.Find("Canvas/GameContent/Pool/Option3/Text").GetComponent<Text>().text;
        GameObject.Find("Canvas/GameContent/Pool/Option3").SetActive(false);
        AnswerCheck(anscheck, score, buttom3);
    }


    public void PushButtom4()
    {
        string buttom4 = GameObject.Find("Canvas/GameContent/Pool/Option4/Text").GetComponent<Text>().text;
        GameObject.Find("Canvas/GameContent/Pool/Option4").SetActive(false);
        AnswerCheck(anscheck, score, buttom4);
    }


    public void PushButtom5()
    {
        string buttom5 = GameObject.Find("Canvas/GameContent/Pool/Option5/Text").GetComponent<Text>().text;
        GameObject.Find("Canvas/GameContent/Pool/Option5").SetActive(false);
        AnswerCheck(anscheck, score, buttom5);
    }


    public void PushButtom6()
    {
        string buttom6 = GameObject.Find("Canvas/GameContent/Pool/Option6/Text").GetComponent<Text>().text;
        GameObject.Find("Canvas/GameContent/Pool/Option6").SetActive(false);
        AnswerCheck(anscheck, score, buttom6);
    }




    //根據錯誤次數記錄
    public int WrongTimes = 0;


    //確認答案是否正確給予分數
    public void AnswerCheck(int value,int ScoreValue,string ans = " ")
    { 
        if(ans.Equals("re"))
        {
            return;
        }
        //選項選擇後的答案確認
        if (anscheck == 0 && ans == QuestionAns[0])
        {
            anscheck += 1;
            score += 100;
            print("現在模式為:" + ModeCheck);
            print("目前分數:" + anscheck + "目前anscheck:" + score);
            GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = score.ToString();
            EQ = EQ.Replace("1.______", "<color=#0000ff><b>" + ans + "</b></color>"); //選擇後放入答案,並做顏色變換
            GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
            return;
        }
        if (anscheck == 0 && ans != QuestionAns[0])
        {
            anscheck += 1;
            score -= 100;
            WrongTimes += 1;
            if (WrongTimes == 1)
            {
                File.AppendAllText(path, "時間:" + DateTimeText + "\n" + "題號:" + x + "\n" + "中文:" + CHQ + "\n");
                File.AppendAllText(path, "英文:" + EQ_Re + "\n");
            }
            print("現在模式為:" + ModeCheck);
            print("目前分數:" + anscheck + "目前anscheck:" + score);
            GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = score.ToString();
            EQ = EQ.Replace("1.______", "<color=#B71B1BFF><b>" + ans + "</b></color>");
            GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
            File.AppendAllText(path, "第1格選擇了:" + ans + "正解為:" + QuestionAns[0] + "\n");
            return;
        }
        if (anscheck  == 1 && ans == QuestionAns[1])
        {
            anscheck += 1;
            score += 100;
            print("現在模式為:" + ModeCheck);
            print("目前分數:" + anscheck + "目前anscheck:" + score);
            GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = score.ToString();
            EQ = EQ.Replace("2.______", "<color=#0000ff><b>" + ans + "</b></color>");
            GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
            if (ModeCheck == 1)
            {
                return;
            }
           
        }
        if (anscheck == 1 && ans != QuestionAns[1])
        {
            anscheck += 1;
            score -= 100;
            WrongTimes += 1;
            if (WrongTimes == 1)
            {
                File.AppendAllText(path, "時間:" + DateTimeText + "\n"+"題號:"+ x+"\n" + "中文:" + CHQ + "\n");
                File.AppendAllText(path, "英文:" + EQ_Re + "\n");
            }
            print("現在模式為:" + ModeCheck);
            print("目前分數:" + anscheck + "目前anscheck:" + score);
            GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = score.ToString();
            EQ = EQ.Replace("2.______", "<color=#B71B1BFF><b>" + ans + "</b></color>");
            GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
            File.AppendAllText(path, "第2格選擇了:" + ans + "正解為:" + QuestionAns[1] + "\n");
            if (ModeCheck == 1)
            {
                return;
            }
        }
        if (anscheck == 2 && ans == QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score += 100;
            print("現在模式為:" + ModeCheck);
            print("目前分數:" + anscheck + "目前anscheck:" + score);
            GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = score.ToString();
            EQ = EQ.Replace("3.______", "<color=#0000ff><b>" + ans + "</b></color>");
            GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
        }
        if (anscheck == 2 && ans != QuestionAns[2] && ModeCheck == 1)
        {
            anscheck += 1;
            score -= 100;
            WrongTimes += 1;
            if (WrongTimes == 1)
            {
                File.AppendAllText(path, "時間:" + DateTimeText + "\n" + "題號:" + x + "\n" + "中文:" + CHQ + "\n");
                File.AppendAllText(path, "英文:" + EQ_Re + "\n");
            }
            print("現在模式為:" + ModeCheck);
            print("目前分數:" + anscheck + "目前anscheck:" + score);
            GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = score.ToString();
            EQ = EQ.Replace("3.______", "<color=#B71B1BFF><b>" + ans + "</b></color>");
            GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ;
            File.AppendAllText(path, "第3格選擇了:" + ans + "正解為:" + QuestionAns[2] + "\n");            
        }
        return;
    }
    public void EnterCheck()
    {
        print("yes");
        print("現在模式為:" + ModeCheck);
        print("最終分數:" + anscheck + "目前anscheck:" + score);
        //最終分數確認是否通關
        if (ModeCheck == 1 && anscheck == 3 && score == 300)
        {
            puzzlecheck += 3;
            GameObject.Find("Canvas/Level").GetComponent<Text>().text = "Got " + StageData.puzzlecheck.ToString() + " puzzles";
            if (puzzlesetting.puzzletype == 3)
            {
                if (puzzlecheck == 9)
                {
                    print("puzzle已打開");
                    OpenPuzzlePanel();
                    CancelInvoke("timer");
                    return;
                }
            }
            if (puzzlesetting.puzzletype == 4)
            {
                if (puzzlecheck == 16)
                {
                    print("puzzle已打開");
                    OpenPuzzlePanel();
                    CancelInvoke("timer");
                    return;
                }
            }
            if (puzzlesetting.puzzletype == 5)
            {
                if (puzzlecheck == 25)
                {
                    print("puzzle已打開");
                    OpenPuzzlePanel();
                    CancelInvoke("timer");
                    return;
                }
            }
            print("答對");
            OpenPanel();
            CancelInvoke("timer");
            return;
        }
        if (ModeCheck == 2 && anscheck == 2 && score == 200)
        {
            puzzlecheck += 3;
            print("現在模式為:" + ModeCheck);
            print("最終分數:" + anscheck + "目前anscheck:" + score);
            GameObject.Find("Canvas/Level").GetComponent<Text>().text = "Got " + StageData.puzzlecheck.ToString() + " puzzles";
            //確認是否開啟拼圖視窗
            if (puzzlesetting.puzzletype==3)
            {
                if (puzzlecheck == 9)
                {
                    print("puzzle已打開");
                    OpenPuzzlePanel();
                    CancelInvoke("timer");
                    return;
                }
            }
            if (puzzlesetting.puzzletype == 4)
            {
                if (puzzlecheck == 16)
                {
                    print("puzzle已打開");
                    OpenPuzzlePanel();
                    CancelInvoke("timer");
                    return;
                }
            }
            if (puzzlesetting.puzzletype == 5)
            {
                if (puzzlecheck == 25)
                {
                    print("puzzle已打開");
                    OpenPuzzlePanel();
                    CancelInvoke("timer");
                    return;
                }
            }

            print("答對");
            OpenPanel();
            CancelInvoke("timer");
            return;
        }
        if (ModeCheck == 1 && anscheck == 3 && score <= 300)
        {
            print("失敗");
            puzzle_time = puzzle_time - 5;
            OpenPanel2();
            CancelInvoke("timer");
            return;
        }
        if (ModeCheck == 2 && anscheck == 2 && score <= 200)
        {
            print("失敗");
            puzzle_time = puzzle_time - 5;
            OpenPanel2();
            CancelInvoke("timer");
            return;
        }
    }
    public string[] FinishPuzzle;
    public string finish;
    
    public int NumPuzzle;
    public void PuzzleCheck()
    {
       
        finish = File.ReadAllText(finishpath);
        int puzzletype = UnityEngine.Random.Range(1, 312);
        FinishPuzzle = finish.Split(',');
        for (int i = 0; i < FinishPuzzle.Length; i++)
        {
            if (int.Parse(FinishPuzzle[i]) == puzzletype)
            {
                puzzletype = UnityEngine.Random.Range(1, 312);
                continue;
            }
            break;
        }
        puzzlenum = puzzletype;
        File.WriteAllText(puzzlepath, puzzlenum.ToString());
    }
    public void Re()
    {
        //重置答案與分數
        anscheck = 0;
        score = 0;
        EQ = EQ_Re;
        //重新打亂順序
        int[] RanOpAgain = new int[6];
        for (int i = 0; i < 6; i++)
        {
            int temp = UnityEngine.Random.Range(1, 7);
            for(int j = 0; j < 6;j++)
            {
                while (RanOpAgain[j] == temp)
                {
                    temp = UnityEngine.Random.Range(1, 7);
                    j = 0;
                    continue;
                }
            }
            RanOpAgain[i] = temp;
            print(temp);
            if (i == 0)
            {
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp).SetActive(true);
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp + "/Text").GetComponent<Text>().text = Option1;
                print(Option1);
            }
            if (i == 1)
            {
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp).SetActive(true);
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp + "/Text").GetComponent<Text>().text = Option2;
                print(Option2);
            }
            if (i == 2)
            {
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp).SetActive(true);
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp + "/Text").GetComponent<Text>().text = Option3;
                print(Option3);
            }
            if (i == 3)
            {
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp).SetActive(true);
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp + "/Text").GetComponent<Text>().text = Option4;
                print(Option4);
            }
            if (i == 4)
            {
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp).SetActive(true);
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp + "/Text").GetComponent<Text>().text = Option5;
                print(Option5);
            }
            if (i == 5)
            {
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp).SetActive(true);
                GameObject.Find("Canvas/GameContent/Pool/Option" + temp + "/Text").GetComponent<Text>().text = Option6;
                print(Option6);
            }

        }



        //重置英文題目
        GameObject.Find("Canvas/GameContent/EnglishQ/Text").GetComponent<Text>().text = EQ_Re;

        //重置分數
        GameObject.Find("Canvas/Score/text").GetComponent<Text>().text = score.ToString();

        //重置時間
        time_int -= 10;
        //呼叫函式,改變目前答案
        AnswerCheck(anscheck, score, "re");

        return;
    }
    public void NextCheck()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
    //過關顯示windows
    public void OpenPanel()
    {

        if (Panel != null)
        {            
            Panel.SetActive(true);
            GameObject.Find("Canvas/Next/answer2").GetComponent<Text>().text = FinalAnswer;
        }
    }
    //拼圖開始
    public void OpenPuzzlePanel()
    {
        if (Panel3 != null)
        {
            Panel3.SetActive(true);
            GameObject.Find("Canvas/PuzzlePanel/answer").GetComponent<Text>().text = FinalAnswer;
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
    public void CloseQuestionPanel()
    {
        if (QuestionPanel != null)
        {
            QuestionPanel.SetActive(false);
        }
    }

}

