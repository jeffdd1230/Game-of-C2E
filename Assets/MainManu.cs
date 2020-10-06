using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManu : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("LevelOption");
    }
    public void Gallery()
    {
        SceneManager.LoadScene("Gallery");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
