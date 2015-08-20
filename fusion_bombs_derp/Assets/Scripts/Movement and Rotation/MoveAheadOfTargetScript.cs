using UnityEngine;
using System.Collections;

public class MoveAheadOfTargetScript : MonoBehaviour {

  public Transform target;

  public float maxMoveAhead = 1;
  public float moveAheadSpeed = 2;

  private Vector2 targetVelocity;
  private Vector2 movement;
	private float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		distance = Vector3.Distance(transform.position, target.transform.position);
		
		if(distance > maxMoveAhead){
			movement = new Vector2(0,0);
		}else{
			targetVelocity = target.GetComponent<Rigidbody2D>().velocity;
			movement = targetVelocity * moveAheadSpeed;
		}
					
	}

	void FixedUpdate()
	{
	// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
