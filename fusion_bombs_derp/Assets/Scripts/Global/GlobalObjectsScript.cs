using UnityEngine;
using System.Collections;

/// <summary>
/// Applies properties to all "global" objects
/// "global" in this sense refers to object that are preserved between stages
/// </summary>
public class GlobalObjectsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		foreach (Transform child in transform)
		{
		  //child is your child transform
			DontDestroyOnLoad(child.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
