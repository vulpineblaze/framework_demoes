using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps all Player data preserved between stages
/// </summary>
public class GlobalPlayerScript : MonoBehaviour {

	public float playerHealth = 10;
	public float currentResources = 0;

	public float enemiesKilled = 0;

	public Transform[] turrets;


	// Use this for initialization
	void Start () {
		// DontDestroyOnLoad(transform.gameObject);
		//transform.gameObject.tag = "GlobalPlayer";
	}
	

	void OnLevelWasLoaded(int level) {
        // if (level == 13)
        //     print("Woohoo");
        swapTurrets();

	}


	// Update is called once per frame
	void Update () {
	
	}

	public void swapTurrets(){
		Transform player = GameObject.Find("Player").transform;	
	    Transform turret;

	    WeaponScript[] weapons = player.GetComponentsInChildren<WeaponScript>();
	    
	    // Debug.Log("weapons.Length , turrets.Length : " + weapons.Length +" , "+ turrets.Length);
	    if(weapons.Length == turrets.Length){
	    	for(int i=0;i < weapons.Length;i++){
	    		Debug.Log(i);
	    		turret = Instantiate(turrets[i], 
	    					weapons[i].transform.position, 
	    					weapons[i].transform.rotation) as Transform;
	    		turret.parent = weapons[i].transform.parent;
	    		turret.localScale = weapons[i].transform.localScale;

	    		Destroy(weapons[i].transform.gameObject);
	    		player.GetComponent<PlayerScript>().reload = true;
	    		

	    		// player.GetComponent<PlayerScript>().Awake();
	    		// turrets[i].position = weapons[i].transform.position;
	    		// Destroy(weapons[i].transform.parent);
	    	}
	    }
	}
}
