using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine.EventSystems;
using System;
using System.Text;
public class data_analvite : MonoBehaviour
{
    public TextAsset data;
    public string[] lineArray;
    public string[] Highly_log_line;
    public string[] log;
    public string org;
    public string[] candy;
    private bool search1;
    private bool search2;
    private bool search3;
    string[][] Array;
    string[] Highly_log_array;
    string[] Jeff;
    public string type;
    public string Record_Path;
    public string Highly_log;
    public string[] Answer;
    public int Syntax, Semantics, Others, Approximate;
    // Start is called before the first frame update
    public void Start()
    {
        Record_Path = Application.persistentDataPath + "/record.txt";
        Highly_log = Application.persistentDataPath + "/Highly_log.txt";
        int x;
        
        lineArray = data.text.Split("\r"[0]);
        Array = new string[lineArray.Length][];
        for (int i = 0; i < lineArray.Length; i++)
        {
            Array[i] = lineArray[i].Split(">"[0]);
        }
    }
    public void convert(int x,string correct,string word)
    {
        print("進入convert");
        print(word);
        string OP = Array[x][15];
        OP = OP.TrimEnd(';');
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
            print("P:"+P[i]);
            //將F分開存入二維陣列
            //print(Cache[i][1]);
            string textcache = Cache[i][1];
            //Feedback欄位E、X、Y(4,23,24)Array[i][4,23,24]
            //字串尋找
            string confuse1 = Array[x][4];
            print("confuse1:"+confuse1);
            string confuse2 = Array[x][23];
            string confuse3 = Array[x][24];
            //string tmp = WrongOption[i];
            string[] xxx = confuse1.Split(new char[4] { ',', ' ', '/', ';' });
            string[] yyy = confuse2.Split(new char[4] { ',', ' ', '/', ';' });
            string[] zzz = confuse3.Split(new char[4] { ',', ' ', '/', ';' });
            /*for(int j = 0; j < zzz.Length; j++)
            {
                print(zzz[j]);
            }*/

            foreach (var item in xxx)
                if (item.Equals(word))
                {
                    type = "Approximate";
                    File.AppendAllText(Record_Path, type + "\n");
                    Approximate++;
                    output(correct,word);
                    return;
                    
                }

            foreach (var item in yyy)
                if (item.Equals(word))
                {
                    
                    type = "Syntax";
                    File.AppendAllText(Record_Path, type + "\n");
                    Syntax++;
                    output(correct, word);
                    return;
                    
                }
            foreach (var item in zzz)
                if (item.Equals(word))
                {
                    
                    Others++;
                    type = "Others";
                    File.AppendAllText(Record_Path, type + "\n");
                    output(correct, word);
                    return;
                    
                }

            //print(test + "\n");



            //print(search);
            //print(confuse);
            //print(i);
        }
       
    }
    // Update is called once per frame
    void Update()
    {

    }
    public string log_highly;
    void output( string correct, string word)
    {
        //找資料夾，如沒有創建
        if (!File.Exists(Highly_log))
        {           
            File.WriteAllText(Highly_log, "", Encoding.UTF8);
        }
        //讀取資料       
        log_highly = File.ReadAllText(Highly_log);
        //將資料用換行區分欄位
        Highly_log_line = log_highly.Split('\n');
        Highly_log_array = new string[Highly_log_line.Length];
        for (int i = 0; i < Highly_log_line.Length; i++)
        {
            Highly_log_array = Highly_log_line[i].Split('>');
            //比對字串
            print("0");
            print(Highly_log_array[0]);
            print("正解["+i+"]"+ correct);
            //如當下正解=correct
            if (Highly_log_array[0] == correct)
            {
                print("/");
                if (Highly_log_array[1].Contains(word))
                {
                    org = Highly_log_array[1];
                    Jeff = org.Split(',');
                    for (int a = 0; a < Jeff.Length; a++)
                    {
                        if (Jeff[a].Contains(word))
                        {
                            int s;

                            candy = Jeff[a].Split('/');
                            s = int.Parse(candy[1]);
                            s = s + 1;
                            Jeff[a] = candy[0] + "/" + s.ToString();

                        }
                    }
                    org = null;
                    for (int j = 0; j < Jeff.Length; j++)
                    {
                        org = org + Jeff[j];
                    }
                    Highly_log_array[1] = org;
                }
                else
                {
                    Highly_log_array[1] = Highly_log_array[1] + "," + word + "/1";
                }
                

            }
            else
            {
               File.AppendAllText(Highly_log, "\n" + correct + ">");
               File.AppendAllText(Highly_log, word + "/1,");
               Highly_log_array = null;
            }
        }
       
    }
}
