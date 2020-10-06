using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class test : MonoBehaviour
{
    public Sprite num1;
    public GameObject rend;
    public static int x = 0;
    // Start is called before the first frame update
    public void Start()
    {
       
        if (test.x == 0)
        {
            x = UnityEngine.Random.Range(1, 7);
        }
        x = test.x;
        print(x);
        if(x == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("Puzzle1");
        }
        if (x == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("Puzzle2");
        }
        if(x == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("Puzzle3");
        }
        if(x == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("Puzzle4");
        }
        if(x == 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("Puzzle5");
        }
        gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(2.257934f, 2.28788f, 1);
        //rend.AddComponent(typeof(Image));
        //num1 = Resources.Load("Puzzle5.png") as Sprite;
        //rend.GetComponent<Image>().sprite = num1;

    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
