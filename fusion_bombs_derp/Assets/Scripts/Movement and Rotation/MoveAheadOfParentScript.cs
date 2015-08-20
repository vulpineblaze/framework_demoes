using UnityEngine;
using System.Collections;

public class MoveAheadOfParentScript : MonoBehaviour {

  private Transform parent;

  public float maxMoveAhead = 1;
  public float moveAheadSpeed = 2;

  private Vector2 targetVelocity;
  private Vector2 movement;
	private float distance;


//   public Transform target;
//   public bool InstantaneousRotation = false;
//   public bool disableRotation = false;
  public Vector2 speed = new Vector2(1, 1);
  public int maxSpeed = 10;
//   public float slerpSpeed = 10.0f;

  
//   private Vector2 movement;
//   bool continousRotation = true;



	// Use this for initialization
	void Start () {
	
	}
	
	void Awake(){
		parent = transform.parent;
	}
	// Update is called once per frame
	void Update () {



		float clean_x = speed.x * (parent.position.x - transform.position.x);
      float clean_y = speed.y * (parent.position.y - transform.position.y);
      
      while( Mathf.Abs(clean_x) > Mathf.Abs(maxSpeed) || Mathf.Abs(clean_y) > Mathf.Abs(maxSpeed)){
        clean_x *= 0.9f;
        clean_y *= 0.9f;
      }

      movement = new Vector2(
        clean_x,
        clean_y);




		// int factor = 1000000;

		// distance = Vector3.Distance(transform.position, parent.transform.position);
		// targetVelocity = parent.GetComponent<Rigidbody2D>().velocity;

		// Vector3 pos = transform.localPosition;
		// Vector3 par = parent.position;

		// if(distance > maxMoveAhead){
		// 	pos.x = 0;
		// }else{
			
		// 	pos.x = (par.x*factor + moveAheadSpeed)/(factor+1);
		// }


		// transform.localPosition = pos;
		// Vector3 par = parent.position;
		// if(distance > maxMoveAhead){
		// 	movement = (targetVelocity + movement*factor)/(factor+1);
		// }else{
			
		// 	movement = (targetVelocity*moveAheadSpeed + movement*factor)/(factor+1);
		// }
					
	}

	void FixedUpdate()
	{
	// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}


}



//   public Transform target;
//   public bool InstantaneousRotation = false;
//   public bool disableRotation = false;
//   public Vector2 speed = new Vector2(1, 1);
//   public int maxSpeed = 10;
//   public float slerpSpeed = 10.0f;

  
//   private Vector2 movement;
//   bool continousRotation = true;

  
//   // Update is called once per frame
//   void Update () {

//     if(continousRotation && !GetComponent<Rigidbody2D>().IsSleeping()){
//       if(InstantaneousRotation){continousRotation=false;}


//       //removes extreme values of x,y and replaces with maxSpeed
//       float clean_x = speed.x * (target.position.x - transform.position.x);
//       float clean_y = speed.y * (target.position.y - transform.position.y);
      
//       while( Mathf.Abs(clean_x) > Mathf.Abs(maxSpeed) || Mathf.Abs(clean_y) > Mathf.Abs(maxSpeed)){
//         clean_x *= 0.9f;
//         clean_y *= 0.9f;
//       }

//       movement = new Vector2(
//         clean_x,
//         clean_y);


//       if((clean_x != 0 || clean_y != 0) && !disableRotation)
//       {
//         Vector3 vectorToTarget = new Vector3(clean_x, + clean_y,0);
//         float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
//         Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
//         transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * slerpSpeed);
//       }

//     }


//   }// END UPDATE

//   void FixedUpdate()
//   {
//     // Apply movement to the rigidbody
//     GetComponent<Rigidbody2D>().velocity = movement;
//   }

// }
