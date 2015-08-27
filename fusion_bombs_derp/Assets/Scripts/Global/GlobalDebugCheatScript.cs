using UnityEngine;
using System.Collections;

public class GlobalDebugCheatScript : MonoBehaviour {


	public Transform blue_turret;

	private GlobalPlayerScript globalPlayer;
	private Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

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
