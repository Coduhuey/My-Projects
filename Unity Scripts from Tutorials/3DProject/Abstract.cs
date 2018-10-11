/*using UnityEngine;
using System.Collections;

public abstract class Abstract : MonoBehaviour {

    private Rigidbody body;

    private float InverseTime;

    private BoxCollider boxcd;

    public Layermask BlockingLayer;

    public float moveTime = 2f;

	virtual void Start () {

        body = GetComponent<Rigidbody>();

        boxcd = GetComponent<BoxCollider>();

        InverseTime = 1f / moveTime;
	}
	
	// Update is called once per frame
	
    public bool Move(int xDir, int yDir, int zDir, out Raycast hit)
    {
        Vector3 start = transform.position;

        Vector3 end = start + new Vector3(xDir, yDir, zDir);

        boxcd.enabled = false;

        hit = Physics.Linecast(start, end, BlockingLayer);

        boxcd.enabled = true;

        if(hit.transform == null)
        {
            StartCoroutine(SmoothMovement);
            return true;
        }

        return false;
    }

    virtual IEnumerator SmoothMovement(Vector3 position)
    {
        float accounting = (transform.position - position).Magnitude;

        while(accounting < Mathf.Epilson)
        {
            Vector3 rigpos = MoveTowards(position, InverseTime * time.deltaTime);

            body.MovePosition(rigpos);

            accounting = (transform.position - position).Magnitude;

            yield return null;
        }
    }

    virtual Abstract AttemptMove<T>(int xDir, int yDir, int zDir)
        where T : Component
    {
        Raycast hit;

        bool canMove = Move(xDir, yDir, zDir, hit);

        if(hit.transform == null)
        {
            continue;
        }

        T hitComponent = GetComponent<T>();

        if(hit.transform != null && !canMove)
        {
            OnCantMove<T>(hitComponent);
        }
    }

    virtual Abstract OnCantMove<T>(T Component)
        where T : Component;

}
*/