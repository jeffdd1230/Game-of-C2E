using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using TMPro;



public class MouseDetector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject particle;
    public Touch touch;
    public int check = 0;
    public float startPos;
    void Start()
    {


    }
    void Update()
    {
        if (Input.touchCount > 0)//如果觸摸次數>0
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began && check == 0)//確認手指點擊螢幕
            {
                startPos = Input.GetTouch(0).position.x;//儲存當下座標
                check = 1;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved && check == 1)//確認手指移動
            {
                if (startPos - Input.GetTouch(0).position.x > 100)//確認滑動距離
                {
                    GameObject.Find("Canvas").GetComponent<PokemonGallery> ().NextButton();//呼叫按鈕
                    check = 2;
                }
                if (Input.GetTouch(0).position.x - startPos > 100)
                {
                    GameObject.Find("Canvas").GetComponent<PokemonGallery>().PreviousButton();
                    check = 2;
                }
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                check = 0;
            }
            return;
        }

    }
}