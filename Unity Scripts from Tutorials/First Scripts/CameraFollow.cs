using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    private float smoothing = 5f;

    Vector3 offset;


	void Start () {
        offset = transform.position - target.position;
	}
	

	void FixedUpdate () { //same function as the player to move evenly
        Vector3 CameraNewPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, CameraNewPos, smoothing * Time.deltaTime);
	}       //Vector3.Lerp moves Vector3's smoothly from two positions
}
