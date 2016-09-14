using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// void Update()
 //     {
 //         if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject != ButtonGameObject)
 //         {
 //             // code snippet
 //         	Application.LoadLevel("Stage1"); // "Stage1" is the scene name
 //         }
 //     }

	// void OnPointerClick(){

	// 	Application.LoadLevel("Stage1"); // "Stage1" is the scene name

	// }

	void OnMouseDown()
	{

	     Application.LoadLevel("Stage1");

	}
}
