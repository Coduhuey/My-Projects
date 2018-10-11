using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour { //abstract details it is incomplete

    public float moveTime = 0.1f;
    public LayerMask blockingLayer; //layer that checks for collisions, this one will check for blocked areas that are already occupied

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;

    // Use this for initialization
    protected virtual void Start() { //means it can be overriden by other classes this script becomes involved with

        boxCollider = GetComponent<BoxCollider2D>(); //component to check collisions
        rb2D = GetComponent<Rigidbody2D>(); //component to apply force to a body

        inverseMoveTime = 1f / moveTime; //allows to multiply moveTime to change the inverse which is more efficient

    }

    protected bool Move (int xDir, int yDir, out RaycastHit2D hit) //out allows for more than one value be returned from the block (what is declared as out specifically)
    {
        Vector2 start = transform.position; //transform.position is converted to 2D, only x and y values and not z
        Vector2 end = start + new Vector2 (xDir, yDir);

        boxCollider.enabled = false; //so that the boxcollider is not hit by the array
        hit = Physics2D.Linecast(start, end, blockingLayer); //casts an imaginary line to check to see if something is inbetween start and end in the blockingLayer, that value is stored into hit
        boxCollider.enabled = true;

        if(hit.transform == null) //if the line didn't hit anything
        {
            StartCoroutine(SmoothMovement(end)); //begins the coroutine of smoothmovement using end as the Vector3 destination variable
            return true; //returns true and ends the block
        }

        return false; //this is the case if if condition is not met
    }

    protected IEnumerator SmoothMovement(Vector3 destination)
    {
        float sqrRemainingDistance = (transform.position - destination).sqrMagnitude; //magnitude is distance, squaring it is more efficient

        while (sqrRemainingDistance > float.Epsilon) //a very small number
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, destination, inverseMoveTime * Time.deltaTime); //movetowards moves a point from a starting position to its end in a certain time
            rb2D.MovePosition(newPosition); //.MovePosition puts the new variable in use

            sqrRemainingDistance = (transform.position - destination).sqrMagnitude;
            yield return null; //waits a moment to re-evaluate the while condition with the just prior change in variable
        }
    }

    protected virtual void AttemptMove<T>(int xDir, int yDir) //T is the generic parameter(so either the player or the enemy units can use this and what they will interact with), other than the two integer parameters, type of component unit will interact with if block, player then it would be a wall to break down
        where T : Component //specifies T is a component
        {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit); //canMove holds the Move functions returned and hit values

        if (hit.transform == null)
        { //if nothing happened to hit, do nothing
            return;
        }

        T hitComponent = hit.transform.GetComponent<T>(); //gets the type T component of the hit object

        if (canMove && hitComponent != null)
        { //if it can't move but hit something that not on its Layer so it can interact with it
            OnCantMove(hitComponent);
        }

 }  

    protected abstract void OnCantMove<T>(T component) //for use on what was hit's position
        where T : Component; //no opening and closing brackets because it is not complete
    
}
