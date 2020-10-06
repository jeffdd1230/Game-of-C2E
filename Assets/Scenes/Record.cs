using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class Record : MonoBehaviour
{
    public string record;
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/record.txt";
        record = File.ReadAllText(path);
        //print(record);
        GameObject.Find("Canvas/Panel/Record").GetComponent<Text>().text = record;
    }
    public void re()
    {
        string path = Application.persistentDataPath + "/record.txt";
        File.WriteAllText(path, "錯誤紀錄:\n");
    }
    // Update is called once per frame
    void Update()
    {
        string path = Application.persistentDataPath + "/record.txt";
        record = File.ReadAllText(path);
        //print(record);
        GameObject.Find("Canvas/Panel/Record").GetComponent<Text>().text = record;
    }
}