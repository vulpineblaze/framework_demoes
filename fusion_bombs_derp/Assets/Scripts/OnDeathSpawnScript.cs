using UnityEngine;
using System.Collections;

public class OnDeathSpawnScript : MonoBehaviour {

	public Transform spawnchild;

	// // Use this for initialization
	// void Start () {
	
	// }
	
	// // Update is called once per frame
	// void Update () {
	
	// }

	void OnDestroy ()
	{
		// var spawned = Instantiate(spawnchild) as Transform;
		var spawned = Instantiate(spawnchild, 
	    					transform.position, 
	    					transform.rotation) as Transform;
	    		// spawned.parent = weapons[i].transform.parent;
	    		// spawned.localScale = transform.localScale;

	}
}
