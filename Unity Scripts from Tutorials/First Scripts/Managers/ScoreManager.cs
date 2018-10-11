using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score; //only score variable that exists, universal due to static


    Text text;


    void Awake ()
    {
        text = GetComponent<Text>();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
    }
}
