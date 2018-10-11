using UnityEngine;
using System.Collections;
using System;

public class Enemy : MovingObject { //Enemy script inherits from MovingObject

    public int playerDamage; //details how much food points will be lost
    private Animator animator; //changes animations
    private Transform target; //used to target position of player
    private bool skipMove; //so enemy can move every other turn
    private float Health = 5;

    public AudioClip attacksound1;
    public AudioClip attacksound2;


	protected override void Start () { //overrides movingobject's start function
        GameManager.instance.AddEnemyToList(this);
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag ("Player").transform; //finds object with tag and takes it's transform position
        base.Start(); //now the base script's start can start
    }


    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        if (skipMove)
        {
            skipMove = false;

            return;
        }
        base.AttemptMove<T>(xDir, yDir);

        skipMove = true;
    }

    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;

        if(Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = target.position.y > transform.position.y ? 1 : -1; //if in the same column then if target.postion.y is greater transform.position.y then move up, if not move down
        }
        else
        {
            xDir = target.position.x > transform.position.x ? 1 : -1; //if not, move x direction closer to target
        }

        AttemptMove<Player>(xDir, yDir); //attemptMove is called, using player as the component and using xDir and yDir; component of the Player class so no variable needed
    }

    protected override void OnCantMove<T>(T component)
    {
        Player hitPlayer = component as Player; //reference to player script as the T component, the parameter

        animator.SetTrigger("enemyAttack");

        SoundManager.instance.RandomizeSfx(attacksound1, attacksound2);

        hitPlayer.LoseFood(playerDamage);
    }

    public void LoseHealth(float loss)
    {
        Health -= loss;
        if (Health < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
