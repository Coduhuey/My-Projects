using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth; //refrences both health based scripts for instance variables/methods
    //EnemyHealth enemyHealth;
    NavMeshAgent nav; //NavMeshAgent variable to use SetDestination and .enabled


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update ()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        nav.SetDestination(player.position); //only transform (existence in plane) component was found, position changes over time
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
