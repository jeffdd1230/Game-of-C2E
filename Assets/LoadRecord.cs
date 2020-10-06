using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadRecord : MonoBehaviour
{
    public void ToRecord()
    {
        SceneManager.LoadScene("Record");
    }
}
