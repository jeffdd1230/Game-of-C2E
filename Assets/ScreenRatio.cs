using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
public class ScreenRatio : MonoBehaviour
{
    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        int ManualWidth = 1280;   //首先記錄下你想要的螢幕解析度的寬
        int ManualHeight = 720;   //記錄下你想要的螢幕解析度的高        //普通安卓的都是 1280*720的解析度
        int manualHeight;

        //然後得到當前螢幕的高寬比 和 你自定義需求的高寬比。通過判斷他們的大小，來不同賦值
        //*其中Convert.ToSingle（）和 Convert.ToFloat() 來取得一個int型別的單精度浮點數（C#中沒有 Convert.ToFloat() ）；
        if (Convert.ToSingle(Screen.height) / Screen.width > Convert.ToSingle(ManualHeight) / ManualWidth)
        {
            //如果螢幕的高寬比大於自定義的高寬比 。則通過公式  ManualWidth * manualHeight = Screen.width * Screen.height；
            //來求得適應的  manualHeight ，用它待求出 實際高度與理想高度的比率 scale
            manualHeight = Mathf.RoundToInt(Convert.ToSingle(ManualWidth) / Screen.width * Screen.height);
        }
        else
        {   //否則 直接給manualHeight 自定義的 ManualHeight的值，那麼相機的fieldOfView就會原封不動
            manualHeight = ManualHeight;
        }

        Camera camera = GetComponent<Camera>();
        float scale = Convert.ToSingle(manualHeight / ManualHeight);
        camera.fieldOfView *= scale;                      //Camera.fieldOfView 視野:  這是垂直視野：水平FOV取決於視口的寬高比，當相機是正交時fieldofView被忽略
        //把實際高度與理想高度的比率 scale乘加給Camera.fieldOfView。
        //這樣就能達到，螢幕自動調節解析度的效果
    }


}
