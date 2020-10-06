using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterStage : MonoBehaviour
{
    public void StageLoad1()
    {
        SceneManager.LoadScene("Stage1");
    }
}
