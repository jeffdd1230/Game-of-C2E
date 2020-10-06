using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackSort : MonoBehaviour
{
    public void BackToSort()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
