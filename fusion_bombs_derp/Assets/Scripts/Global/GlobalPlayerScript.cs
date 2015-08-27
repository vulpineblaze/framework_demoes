using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps all Player data preserved between stages
/// </summary>
public class GlobalPlayerScript : MonoBehaviour {

	public float playerHealth = 10;
	public float currentResources = 0;

	public float enemiesKilled = 0;


	// Use this for initialization
	void Start () {
		// DontDestroyOnLoad(transform.gameObject);
		//transform.gameObject.tag = "GlobalPlayer";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
