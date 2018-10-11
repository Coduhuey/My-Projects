using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MovingObject { //inherits from the MovingObject script

    public int wallDamage = 1; //damage done player does to wall
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDelay = 1f;
    public Text foodText;

    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip eatSound1;
    public AudioClip eatSound2;
    public AudioClip drinkSound1;
    public AudioClip drinkSound2;
    public AudioClip gameOverSound;

    private Animator animator; //refrence to animator component
    private int food; //stores score for every level

	// Use this for initialization
	protected override void Start () { //different use of start that in the moving object class which is why protected and override are added

        animator = GetComponent<Animator>();

        food = GameManager.instance.playerFoodPoints; //keeps the food score between levels

        foodText.text = "Food: " + food;

        base.Start(); //declares the start function for the base class, the moving object class

	}

    private void OnDisable() //works when the player gameobject is disabled
    {
        GameManager.instance.playerFoodPoints = food; //stores the value of food as levels change
    
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.instance.playersTurn) return; //if it's not their turn the rest does not follow

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical"); //int because would normally return a float value

        if (horizontal != 0)
            vertical = 0; //prevents vertical movement during horizontal movement

        if (horizontal != 0 || vertical != 0)
            AttemptMove<Wall>(horizontal, vertical); //specifies what T is for what this script should interact with
    }

    protected override void AttemptMove<T> (int xDir, int yDir) //T is the type of component this will encounter
    {
        food--; //loses one food point every move
        foodText.text = "Food: " + food; //updates foodText as food changes

        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit; //refrences the ray in the original attemptmove function

        if(Move(xDir, yDir, out hit))
        {
            SoundManager.instance.RandomizeSfx(moveSound1, moveSound2); //using the functions and declared variable of itself from the SoundManager script
        }

        CheckIfGameOver(); //checks if food = 0, for gameover

        GameManager.instance.playersTurn = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay); //one second pause before function is called
            enabled = false;
        }
        else if (other.tag == "Food")
        {
            food += pointsPerFood;
            foodText.text = "+ " + pointsPerFood + "Food: " + food;

            SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);

            other.gameObject.SetActive(false); //deactivates the collide food gameobject
        }
        else if(other.tag == "Soda")
        {
            food += pointsPerSoda;
            foodText.text = "+ " + pointsPerSoda + "Food: " + food;

            SoundManager.instance.RandomizeSfx(drinkSound1, drinkSound2);

            other.gameObject.SetActive(false);
        }

    }
    protected override void OnCantMove <T> (T component) //takes component T and the type of it
    {
        Wall hitWall = component as Wall; //the parameter as a wall
        hitWall.DamageWall(wallDamage);
        animator.SetTrigger("playerChop"); //uses the animator's trigger to set in action the chopping animation

    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel); //loads the last loaded scene
    }

    public void LoseFood(int loss)
    {
        animator.SetTrigger("playerHit");
        food -= loss;
        foodText.text = "- " + loss + " Food: " + food;
        CheckIfGameOver(); //because during this loss, a gameover may need to be called
    }

    private void CheckIfGameOver()
    {
        if (food <= 0)
        {
            SoundManager.instance.PlaySingle(gameOverSound);
            SoundManager.instance.musicSource.Stop(); //stops background music

            GameManager.instance.GameOver(); //calls GameManger class's gameover function
        }
    }
}
