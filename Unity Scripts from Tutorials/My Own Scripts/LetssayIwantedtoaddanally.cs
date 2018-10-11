using UnityEngine;
using System.Collections;
using System;

public class LetssayIwantedtoaddanally : MovingObject {

    private Animator animate;
    public float damageEnemy = 5;
    private Transform destination;
    bool turn1;
    bool turn2;

	// Use this for initialization
	protected override void Start () {
        animate = GetComponent<Animator>();
        destination = GameObject.FindGameObjectWithTag("Enemy").transform;
        base.Start();
    }

    public void MoveAlly()
    {
        int xDir = 0;
        int yDir = 0;

        if(Mathf.Abs(destination.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = transform.position.y < destination.position.y ? 3 : -3;
        }
        else
        {
            xDir = transform.position.x < destination.position.x ? 3 : -3;
        }
        AttemptMove<Enemy>(xDir, yDir); //where component is chosen
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        if (turn1)
        {
            if (turn2)
            {
                base.AttemptMove<T>(xDir, yDir);
                turn1 = false;
                turn2 = false;
            }
            turn2 = true;
        }
        turn1 = true;
    }

    protected override void OnCantMove<T>(T component)
    {
        Enemy hitEnemy = component as Enemy; //hitenemy is set to thge variable parameter component
        animate.SetTrigger("attackofally");
        hitEnemy.LoseHealth(damageEnemy); //set a function in enemy for this
    }
}
