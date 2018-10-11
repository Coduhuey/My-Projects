using UnityEngine;
using System.Collections;
using System;

public class MegaEnemy : MovingObject {

    private Animator animate;
    public int damage = 30;
    private Transform target;
    private bool cando;

	// Use this for initialization
	protected override void Start () {
        animate = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
	}
	
	
	public void MoveMEnemy() {
        int xDir = 0;
        int yDir = 0;

        if (Math.Abs(transform.position.x - target.position.x) < float.Epsilon)
        {
            yDir = target.position.y > transform.position.y ? 2 : -2;
        }
        else
        {
            xDir = target.position.x < transform.position.x ? -2 : 2;
        }
        AttemptMove<Player>(xDir, yDir);
	}

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        if (cando)
        {
            base.AttemptMove<T>(xDir, yDir);
            cando = false;
            return;
        }
        cando = true;
        return;

    }

    protected override void OnCantMove<T>(T component)
    {
        Player hurts = component as Player;
        animate.SetTrigger("megaAttack");
        hurts.LoseFood(damage);
    }
}
