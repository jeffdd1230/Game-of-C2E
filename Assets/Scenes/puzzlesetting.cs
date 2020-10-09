using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
public class puzzlesetting : MonoBehaviour
{
    public static int puzzletype=3;

    public void pushthree()
    {
        puzzletype = 3;
    }
    public void pushfour()
    {
        puzzletype = 4;
    }
    public void pushfive()
    {
        puzzletype = 5;
    }
}
