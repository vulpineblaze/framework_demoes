using UnityEngine;
using System.Collections;

public class AwakeOnDistanceScript : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	public float wakeUpDistance = 5f;
	private float currentDistance = 0f;
 
// Use this for initialization
    void Start () {
        player =  GameObject.Find("Player");	
    }
 
// Update is called once per frame
    void Update () {
    	currentDistance = Vector2.Distance (transform.position, player.transform.position);
        if (currentDistance < wakeUpDistance) {
            GetComponent<Rigidbody2D>().WakeUp();
        }else{
        	GetComponent<Rigidbody2D>().Sleep();
        }
    }



}