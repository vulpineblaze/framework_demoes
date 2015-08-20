using UnityEngine;
using System.Collections;

public class MoveAheadOfParentScript : MonoBehaviour {

  private Transform parent;

  public float maxMoveAhead = 1;
  public float moveAheadSpeed = 2;

  private Vector2 targetVelocity;
  private Vector2 movement;
	private float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	void Awake(){
		parent = transform.parent;
	}
	// Update is called once per frame
	void Update () {
		int factor = 1000000;

		distance = Vector3.Distance(transform.position, parent.transform.position);
		targetVelocity = parent.GetComponent<Rigidbody2D>().velocity;

		Vector3 pos = transform.localPosition;
		Vector3 par = parent.position;

		if(distance > maxMoveAhead){
			pos.x = 0;
		}else{
			
			pos.x = (par.x*factor + moveAheadSpeed)/(factor+1);
		}


		transform.localPosition = pos;
		// Vector3 par = parent.position;
		// if(distance > maxMoveAhead){
		// 	movement = (targetVelocity + movement*factor)/(factor+1);
		// }else{
			
		// 	movement = (targetVelocity*moveAheadSpeed + movement*factor)/(factor+1);
		// }
					
	}

	// void FixedUpdate()
	// {
	// // Apply movement to the rigidbody
	// 	GetComponent<Rigidbody2D>().velocity = movement;
	// }
}
