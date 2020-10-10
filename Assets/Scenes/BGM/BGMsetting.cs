using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGMsetting : MonoBehaviour
{
    public AudioClip music;
    public static AudioSource BGM;
    public Slider slider;
    private static BGMsetting instance=null;
    public Dropdown BGMchoice;
    static bool AudioBegin = false;
    public static string BGMcheck="happytime";
    public static float volumenum;
    public static int check = 0;
    public GameObject Panel;
    public static int checkcanvas=0;
    public GameObject Canvas;
    //public GameObject option;
    // Start is called before the first frame update

    public void Awake()
    {
        Canvas.SetActive(true);
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            
            DontDestroyOnLoad(transform.gameObject);
            //DontDestroyOnLoad(option);
            instance = this;
        }
        
        BGMstart();
        
        
    }
    public void BGMstart()
    {
        BGMcheck = BGMchoice.options[BGMchoice.value].text;
        music = Resources.Load<AudioClip>("BGM/"+ BGMcheck);
        BGM = this.GetComponent<AudioSource>();
        BGM.loop = true;
        BGM.volume = 0.08f;
        BGM.clip = music;
        BGM.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (BGMchoice != null)
        {
            if (BGMcheck != BGMchoice.options[BGMchoice.value].text && Speak.status == "Stoping")
            {
                BGMstart();
            }
            if(BGM == null)
            {
                BGMstart();
            }
        }
        
        if (slider != null)
        {
            volumenum = slider.value;
            BGM.volume = volumenum;
        }
        
    }
    public void openbgmpanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
        if (Panel != null)
        {
            Panel.SetActive(true);
            check += 1;
        }
    }
    public void closebgmpanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }
    public void Open()
    {
        Canvas.SetActive(true);
    }
    public void Close()
    {
        Canvas.SetActive(false);
    }
}
