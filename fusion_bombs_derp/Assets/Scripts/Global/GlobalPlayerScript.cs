using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps all Player data preserved between stages
/// </summary>
public class GlobalPlayerScript : MonoBehaviour {

	public int playerHealth = 10;

	// Use this for initialization
	void Start () {
		// DontDestroyOnLoad(transform.gameObject);
		//transform.gameObject.tag = "GlobalPlayer";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
