using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{

    public GameObject gameManager;

    void Awake()
    {
        if (GameManager.instance == null) //using the static from the game manager script
            Instantiate(gameManager); //this one is the set gameObject
        
    }

}
