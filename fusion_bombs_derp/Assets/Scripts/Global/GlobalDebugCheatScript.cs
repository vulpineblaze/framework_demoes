using UnityEngine;
using System.Collections;

public class GlobalDebugCheatScript : MonoBehaviour {


	public Transform blue_turret;

	private GlobalPlayerScript globalPlayer;
	private Transform player;
	// Use this for initialization
	private GameObject st;
	public Transform spawnedBadGuy;
	private float whereToSpawn = 8;
	private float countOfSpawn = 0;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        st = GameObject.Find("Saurothrop");
        if(st == null){
        	st = GameObject.Find("Saurothrop(Clone)");
        }

        if(st == null && countOfSpawn < 10){
        	var temp = Instantiate(spawnedBadGuy) as Transform; //better be an ST though lol
        	MovetoTargetScript mover = temp.GetComponent<MovetoTargetScript>();
        	mover.target = GameObject.Find("Player").transform;
        	countOfSpawn++;
        	float here = whereToSpawn * countOfSpawn;
        	temp.transform.position = new Vector3(here,here,0);
        }

		if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T)){
			globalPlayer = GameObject.Find("GlobalPlayerObject").GetComponent<GlobalPlayerScript>();
	    	player = GameObject.Find("Player").transform;	

	    	for(int i=0;i < globalPlayer.turrets.Length;i++){
	    		// Transform new_turret = Instantiate(blue_turret) as Transform;
	    		globalPlayer.turrets[i] = blue_turret;
	    		// globalPlayer.gameObject.SetActive(true);
	    		// Destroy(new_turret.gameObject);
	    	}

	    	globalPlayer.swapTurrets();
	    	// foreach(Transform turret in globalPlayer.turrets){
	    	// 	Transform blue_turret = Instantiate(blue_turret) as Transform;
	    	// 	turret.transform = blue_turret;
	    	// }
		}
	}
}
