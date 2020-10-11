using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
public class PokemonGallery : MonoBehaviour
{
    public string puzzle;
    public string[] lineArray;
    public static int x;
    public static int y;
    public int n;
    public int panel;
    public int finishpuzzle;
    public string puzzlepath;
    public int num;
    public static int fullsize;
    // Start is called before the first frame update
    public void Start()
    {
        finishpuzzle = 0;
        num = 1;
        n = 0;
        panel = 0;
        string puzzlepath = Application.persistentDataPath + "/FinishPuzzle.txt";
        puzzle = File.ReadAllText(puzzlepath);
        lineArray = puzzle.Split(',');
        x = 1;
        y = 12;
        for (int i = x; i <= y; i++)
        {
            if (x == 1)
            {
                GameObject.Find("Canvas/" + i).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("empty/Pokemon" + i);
                GameObject.Find("Canvas/" + i).GetComponent<SpriteRenderer>().transform.localScale = new Vector3(28.0148f, 32.22427f, 72.03652f);
            }
        }
            Gallery();
    }
    public void Update()
    {
        GameObject.Find("Canvas/finish/count").GetComponent<Text>().text = finishpuzzle.ToString(); ;
    }
    public void Gallery()
    {
        for(int i = x; i <= y; i++)
        {
            if (x == 1)
            {
                GameObject.Find("Canvas/" + i).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("empty/Pokemon" + i);
                GameObject.Find("Canvas/" + i).GetComponent<SpriteRenderer>().transform.localScale = new Vector3(28.0148f, 32.22427f, 72.03652f);
            }
            
            GameObject.Find("Canvas/Button/" + num + "/Text").GetComponent<Text>().text = i.ToString();
            for (int j = 0; j < lineArray.Length; j++)
            {
                if(i == int.Parse(lineArray[j]))
                {
                    panel = i - (12*n);
                    
                    if (num == panel)
                    {
                        GameObject.Find("Canvas/Button/" + num ).SetActive(true);
                    }
                    GameObject.Find("Canvas/"+panel).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("original/Pokemon" + i);
                    GameObject.Find("Canvas/"+panel).GetComponent<SpriteRenderer>().transform.localScale = new Vector3(28.0148f, 32.22427f, 72.03652f);
                }
            }
            num += 1;
            if (num == 13)
            {
                num = 1;
            }
        }

        finishpuzzle = lineArray.Length-1;
        GameObject.Find("Canvas/finish/count").GetComponent<Text>().text = finishpuzzle.ToString();
    }
    public int page = 0;
    public void NextButton()
    {
        
        x = x + 12;
        page = page + x;
        y = y + 12;
        
        n += 1;
        if (y >= 312)
        {
            x = 1;
            y = 12;
            n = 0;
        }
        for (int i=1;i<=12;i++)
        {
            GameObject.Find("Canvas/Button/" + i).SetActive(false);
        }
        for (int k = 1; k <= 12; k++)
        {
            GameObject.Find("Canvas/" + k).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("empty/Pokemon" + page);
            GameObject.Find("Canvas/" + k).GetComponent<SpriteRenderer>().transform.localScale = new Vector3(28.0148f, 32.22427f, 72.03652f);
            page += 1;
        }
        page = 0;
        Gallery();
    }
    public void PreviousButton()
    {
        if (x == 1)
        {
            return;
        }
        x = x - 12;
        page = page + x;
        y = y - 12;
        n -= 1;
        for (int i = 1; i <= 12; i++)
        {
            GameObject.Find("Canvas/Button/" + i).SetActive(false);
        }
        for (int k = 1; k <= 12; k++)
        {
            GameObject.Find("Canvas/" + k).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("empty/Pokemon" + page);
            GameObject.Find("Canvas/" + k).GetComponent<SpriteRenderer>().transform.localScale = new Vector3(28.0148f, 32.22427f, 72.03652f);
            page += 1;
        }
        page = 0;
        Gallery();
    }
    public void PushButton1()
    {
        string button = GameObject.Find("Canvas/Button/1/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton2()
    {
        string button = GameObject.Find("Canvas/Button/2/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton3()
    {
        string button = GameObject.Find("Canvas/Button/3/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton4()
    {
        string button = GameObject.Find("Canvas/Button/4/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton5()
    {
        string button = GameObject.Find("Canvas/Button/5/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton6()
    {
        string button = GameObject.Find("Canvas/Button/6/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton7()
    {
        string button = GameObject.Find("Canvas/Button/7/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton8()
    {
        string button = GameObject.Find("Canvas/Button/8/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton9()
    {
        string button = GameObject.Find("Canvas/Button/9/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton10()
    {
        string button = GameObject.Find("Canvas/Button/10/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton11()
    {
        string button = GameObject.Find("Canvas/Button/11/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
    public void PushButton12()
    {
        string button = GameObject.Find("Canvas/Button/12/Text").GetComponent<Text>().text;
        fullsize = int.Parse(button);
        SceneManager.LoadScene("Pokemon");
    }
}
