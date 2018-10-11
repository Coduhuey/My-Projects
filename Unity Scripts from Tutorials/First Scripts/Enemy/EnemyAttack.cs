using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //to check if gameobject is player
        anim = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter(Collider other) //SMART COMBO
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime; //smart use of a float variable
        
        if(playerInRange && timer >= timeBetweenAttacks && enemyHealth.currentHealth >= 0)
        {
            Attack();
        }
        if(playerHealth.currentHealth == 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        timer = 0f; //remember to reset timer

        if (playerHealth.currentHealth >= 0)
        {
            playerHealth.TakeDamage(attackDamage); //good to set to remember from beginning
        }
    }
}
