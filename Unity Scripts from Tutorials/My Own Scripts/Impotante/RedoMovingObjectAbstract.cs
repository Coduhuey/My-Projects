using UnityEngine;
using System.Collections;

public abstract class RedoMovingObjectAbstract : MonoBehaviour {

    public float moveTime;
    private BoxCollider2D col;
    private Rigidbody2D rigbod;
    public LayerMask collayer;
    private float inverseTime;


	void Start () {
        col = GetComponent<BoxCollider2D>();
        rigbod = GetComponent<Rigidbody2D>();
        inverseTime = 1f / moveTime;
	}
	
    bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        col.enabled = false;

        hit = Physics2D.Linecast(start, end, collayer);

        col.enabled = true;

        if (hit.transform == null)
        {
            StartCoroutine(NiceMoves(end));
            return true;
        }
        return false;
    }

   protected IEnumerator NiceMoves(Vector3 endpoint)
    {
        float RemainingDist = (transform.position - endpoint).sqrMagnitude;

        while(RemainingDist > float.Epsilon)
        {
            Vector3 MoveTo = Vector3.MoveTowards(rigbod.position, endpoint, inverseTime * Time.deltaTime);

            rigbod.MovePosition(MoveTo);

            RemainingDist = (transform.position - endpoint).sqrMagnitude;

            yield return null;
        }
    }

    protected virtual void Attempt<T>(int xDir, int yDir)
          where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);

        if(hit.transform == null)
        {
            return;
        }

        T hitComponent = hit.transform.GetComponent<T>();

        if(canMove && hitComponent != null)
        {
            OnCantMove<T>(hitComponent);
        }
    }

    protected abstract void OnCantMove<T>(T Component)
        where T : Component;
   
}
