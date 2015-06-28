using UnityEngine;
using System.Collections;

public class MoveWithPlayerScript : MonoBehaviour {

    public Transform target;
    public float dampTime = 0.15f;
    public float FactorInPercent = 100.0f;
    private Vector3 velocity = Vector3.zero;
    Vector3 delta;

	// Use this for initialization
	void Start () {
		delta = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
	        {
	        	
	        	Vector3 destination = target.position * (FactorInPercent/100.0f);
	        	transform.position = Vector3.SmoothDamp(transform.position, destination + delta, ref velocity, dampTime);
	        }

	}
}



