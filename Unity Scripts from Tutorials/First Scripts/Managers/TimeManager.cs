using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    Canvas canvas;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled; //reverses the prior
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; //if Time.timeScale is equal zero, make it one, if not make it to zero (normal time speed)
    }

    public void Return()
    {
        SceneManager.LoadScene(2);
    }
}