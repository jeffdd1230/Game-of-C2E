using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SortManu : MonoBehaviour
{
    public void Option1()
    {
        SceneManager.LoadScene("GameOption1");
    }
    public void Option2()
    {
        SceneManager.LoadScene("GameOption2");
    }
    public void Option3()
    {
        SceneManager.LoadScene("GameOption3");
    }
}
