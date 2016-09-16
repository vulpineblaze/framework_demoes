using UnityEngine;
using System.Collections;

public class DistantObjectIndicatorScript : MonoBehaviour {

	// Use this for initialization
	private SelfIndicatorScript[] indicators;

	private Vector3 start;
	private Vector3 end;
	private Vector3 enemyPos;

	void Start () {
		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		collider.size = new Vector3(Screen.width,Screen.height,0);
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
			enemyPos = indicator.transform.position;
			Ray ray = camera.ScreenPointToRay(indicator.transform.position);
			start = ray.origin;
			end = ray.direction;
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow,20,true);
			Debug.DrawLine(ray.origin, ray.direction * 100, Color.red);
			// Gizmos.DrawRay(ray.origin, ray.direction * 100);
		}

// 
	}
}
