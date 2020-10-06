using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    public void Next()
    {
        if (puzzlesetting.puzzletype == 3)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (puzzlesetting.puzzletype == 4)
        {
            SceneManager.LoadScene("4piece");
        }
        if (puzzlesetting.puzzletype == 5)
        {
            SceneManager.LoadScene("5pieces");
        }

    }
    public void Nextstage()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
