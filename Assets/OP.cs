using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class OP : MonoBehaviour
{
    public VideoPlayer VideoPlayer;


    void Start()
    {
        //VideoPlayer = GetComponent<VideoPlayer>(); //2.初始化VideoPlayer對象
        //VideoPlayer.loopPointReached += EndReached; //當前clip播放完成調用的事件
        //VideoPlayer.SetTargetAudioSource(0, GetComponent<AudioSource>());
        VideoPlayer.Play(); //開始播放視頻
    }
    void Update()
    {
        if (VideoPlayer.isPlaying)
        {
            //視頻正在播放時，如果播放完畢或者點擊屏幕，則停止播放。
            if (VideoPlayer.clip.name == "Opening" && (ulong)VideoPlayer.frame >= VideoPlayer.frameCount)
            {
                //判斷是否播放完畢
                VideoPlayer.Stop(); //停止播放
            }
            if (Input.GetMouseButtonDown(0))
            {
                //點擊鼠標左鍵（觸摸屏幕）
                VideoPlayer.Stop();
            }
        }
    }
    private void EndReached(VideoPlayer source)
    {
        SceneManager.LoadScene("MainMenu");
    }
}

