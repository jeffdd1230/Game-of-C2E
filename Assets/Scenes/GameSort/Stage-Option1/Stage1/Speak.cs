using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Speak : MonoBehaviour
{
    public AudioSource audio;
    AudioClip myClip;
    public string ch ;
    public string url;
    public string sound;
    public string voice;
    public static string status = "Stoping";
    public void Start()
    {
        ch = StageData.speak;
        if(GameOption.sound!=null&& GameOption.voice != null)
        {
            sound = GameOption.sound;
            voice = GameOption.voice;
        }
        
        url = "https://api.voicerss.org/?key=37b5caeb45a64681ad49e44e70d1328e&hl=en-" + voice+"&c=WAV&v="+sound+"&src=" + ch;
    }


    IEnumerator DownloadAndPlay()
    {
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);
        yield return www.Send();
        AudioSource audio = GetComponent<AudioSource>();
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            myClip = DownloadHandlerAudioClip.GetContent(www);
            audio.clip = myClip;
            status = "Playing";
            BGMsetting.BGM.Pause();
            audio.Play();
            Invoke("stop", audio.clip.length);

        }
        
    }
    public void stop()
    {
        status = "Stoping";
        print("stop playing");
        BGMsetting.BGM.Play();
    }
    public void button()
    {
        StartCoroutine(DownloadAndPlay());
    }
    //public void button1()
    //{
    //    StartCoroutine(DownloadAndPlay());
    //}
}
