using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageLoad : MonoBehaviour
{
    public static int Stagetype = 1;
    public void StageLoad1()
    {
        if(Stagetype == 1)
        {
            SceneManager.LoadScene("Stage1");
            Stagetype = 1;
            GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Easy";
        }
        
        if(Stagetype == 2)
        {
            SceneManager.LoadScene("Stage1Hard");
           Stagetype = 2;
          GameObject.Find("Canvas/Stage Level").GetComponent<Text>().text = "Hard";
        }
        
    }
}
