using UnityEngine;
using System;
using System.Collections;

public class PlanetMenuScript : MonoBehaviour {


	public float startBarDisplay = 0.0f; //current progress
	public float barTime = 5.0f; //current progress
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	private bool wasClicked = false;

	private float barDisplay;
	private DateTime startTime;

	private string buttonText = "Mine This Planet";

	private GlobalPlayerScript globalPlayer;


	// Use this for initialization
	void Start () {
		barDisplay = startBarDisplay;
		globalPlayer = GameObject.Find("GlobalPlayerObject").GetComponent<GlobalPlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.gameObject.activeSelf){
			if(wasClicked){
				barDisplay = (float)(System.DateTime.Now - startTime).TotalSeconds / (barTime);
			}
			if(barDisplay > 1){
				//Destroy(gameObject);
				wasClicked = false;
				buttonText = "Mine This\nPlanet Again";
				globalPlayer.currentResources += 10;
				barDisplay = 0;
				// wasEverMined = true;
			}

		}
		float inputX = Input.GetAxis("Horizontal");
    	float inputY = Input.GetAxis("Vertical");
		if(inputX != 0 || inputY != 0){
			if(barDisplay != 0){
				barDisplay = 0;
				wasClicked = false;
				buttonText = "Mine This\nPlanet Again";
			}
		}
	
	}

	void OnGUI(){

		//buttons and shit
		const int buttonWidth = 128;
    	const int buttonHeight = 60;

		// Draw a button to start the game
	    if (GUI.Button(
	      // Center in X, 2/3 of the height in Y
	      new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight),
	      buttonText
	      ))
	    {
	      // On Click, load the first level.
	    	wasClicked = true;
	    	startTime = System.DateTime.Now;
	    	buttonText = "Mining!";
	    }

	    if(wasClicked){
		    GUI.BeginGroup(new Rect(
		    					Screen.width / 2 - (buttonWidth / 2) - (pos.x/2), 
		    					Screen.height / 2 - (buttonHeight / 2) - (pos.y/2), 
		    					size.x, 
		    					size.y));
	             GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
	         
	             //draw the filled-in part:
	             GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
	                 GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
	             GUI.EndGroup();
	         GUI.EndGroup();
     	}

	}
}
