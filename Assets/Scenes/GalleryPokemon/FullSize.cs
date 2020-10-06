using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FullSize : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        GotPhoto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GotPhoto()
    {
        GameObject.Find("Pokemon1").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("original/Pokemon" + PokemonGallery.fullsize);
    }
    public void PushBack()
    {
        Screen.orientation = ScreenOrientation.Unknown;
        SceneManager.LoadScene("Gallery");
    }
}
