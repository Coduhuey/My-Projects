using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for Lists
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float levelStartDelay = 2f;
    public float turnDelay = .1f;
    public static GameManager instance = null; //static allows for all scripts to use it as it is assigned to this class, made null so loader can start it
    public BoardManager boardScript;
    public int playerFoodPoints = 100;
    [HideInInspector] //variable won't be displayed in editor
    public bool playersTurn = true;

    private Text levelText;
    private GameObject levelImage;
    private int level = 1;
    private List<Enemy> enemies;
    private bool enemiesMoving;
    private bool doingSetup;

	void Awake () {
        if (instance == null) // Why?
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Why?

        enemies = new List<Enemy>();

        boardScript = GetComponent<BoardManager>(); //allows for gameManager to call functions with boardscript.(function(using parameter))
        InitGame();
	}

    private void OnLevelWasLoaded (int index)
    {
        level++;

        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;

        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>(); //looks quite handy doesn't it?
        levelText.text = "Day" + level;
        levelImage.SetActive(true);

        //A series of logic balances, pay attention to the invoke use, it seems helpful with delay

        Invoke("HideLevelImage", levelStartDelay); //Invoke((function), (float delay before function is initiated))

        //
        enemies.Clear();
        boardScript.SetupScene(level);
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = "After " + level + " days, you starved.";
        levelImage.SetActive(true);
        enabled = false; //disables gameManager script
    }

    void Update()
    {
        if(playersTurn || enemiesMoving || doingSetup) //if one was true, player can't move
        {
            return;
        }
        StartCoroutine(MoveEnemies());
    }

    public void AddEnemyToList(Enemy script) //Enemies are added to GameManager's refrence
    {
        enemies.Add(script);
    }
	

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].moveTime);
        }
        playersTurn = true;
        enemiesMoving = false;
    }

}
