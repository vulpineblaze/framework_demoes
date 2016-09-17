using UnityEngine;
using System.Collections;

public class DistantObjectIndicatorScript : MonoBehaviour {

	// Use this for initialization
	public float radius = 0.3f;

	public Transform player;

	private SelfIndicatorScript[] indicators;

	// private Vector3 start;
	// private Vector3 end;

	public Vector3 testTest;

	void Start () {
		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		collider.size = new Vector3(Screen.width,Screen.height,0);
		float screenAdjust = Mathf.Min(Screen.height,Screen.width) *0.45f ;

		// var worldToPixels = ((Screen.height / 2.0f) / Camera.main.orthographicSize);
		var worldToPixelsInverted = (Camera.main.orthographicSize/(Screen.height / 2.0f) );

		radius = worldToPixelsInverted * screenAdjust;


	}
	
	// Update is called once per frame
	void Update () {
		// Ray ray = camera.ScreenPointToRay(new Vector3(200, 200, 0));
  //       Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

		// hingeJoints = GetComponents<HingeJoint>();
  //       foreach (HingeJoint joint in hingeJoints) {
  //           joint.useSpring = false;
  //       }

		// GameObject.Find("First Person Controller")
		Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		transform.position = camera.transform.position;

		indicators = GameObject.Find("4 - Foreground").GetComponentsInChildren<SelfIndicatorScript>();
		foreach (SelfIndicatorScript indicator in indicators){
			Vector3 enemyPos = indicator.transform.position;

			Transform arrow = null;
			foreach(Transform child in indicator.transform){
				if(child.gameObject.tag == "OnlyOne"){
					arrow = child;
				}
			}
			// Transform arrow = indicator
			if(arrow == null){
				arrow = Instantiate(indicator.arrowPrefab) as Transform;
				arrow.parent = indicator.transform;

				// var heading = enemyPos - transform.position;
				// var distance = heading.magnitude;
				// var direction = heading / distance; // This is now the normalized direction.

				 // Vector3 originOfAngle; //this will be where you are casing your angle from.
				 // Vector3 angle; //this will be your target angle.
				 // float distanceToTestFor; //this will be your testing radius
				 // //set the above values however you wish
				 

			}


			Ray rayToTest = new Ray( player.position, enemyPos );
			Vector3 targetPoint = rayToTest.GetPoint(radius);
			testTest = targetPoint;

			// arrow.rotation = rayToTest.direction;
			
			float angle = GetAngle(transform.position.x, 
												transform.position.y,
												enemyPos.x,
												enemyPos.y);

			arrow.rotation = Quaternion.Euler(rayToTest.direction.x , 
								rayToTest.direction.y, 
								rayToTest.direction.z - angle);

			// Vector3 relativePos = player.position - enemyPos;
	  //       Quaternion rotation = Quaternion.LookRotation(relativePos);
	  //       arrow.rotation = rotation;

			arrow.position = targetPoint + new Vector3(0,0,1);

			// Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow,20,true);
			// Debug.DrawLine(ray.origin, ray.direction * 100, Color.red);
			// Gizmos.DrawRay(ray.origin, ray.direction * 100);
		}

// 
	}


	float GetAngle(float X1, float Y1, float X2, float Y2) {
	 
	        // take care of special cases - if the angle
	        // is along any axis, it will return NaN,
	        // or Not A Number.  This is a Very Bad Thing(tm).
	        if (Y2 == Y1) {
	            return (X1 > X2) ? 180 : 0;
	        }
	        if (X2 == X1) {
	            return (Y2 > Y1) ? 90 : 270;
	        }
	       
	        float tangent = (X2 - X1) / (Y2 - Y1);
	        // convert from radians to degrees
	        double ang = (float) Mathf.Atan(tangent) * 57.2958;
	        // the arctangent function is non-deterministic,
	        // which means that there are two possible answers
	        // for any given input.  We decide which one here.
	        if (Y2-Y1 < 0) ang -= 180;
	 
	 
	        // NOTE that this does NOT need to be normalised.  Arctangent
	        // always returns an angle that is within the 0-360 range.
	       
	 
	        // barf it back to the calling function
	        return (float) ang;
	   
	    }
}
