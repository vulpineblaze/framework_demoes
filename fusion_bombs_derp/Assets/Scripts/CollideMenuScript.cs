using UnityEngine;
using System.Collections;

public class CollideMenuScript : MonoBehaviour {

	// Use this for initialization
	private bool isCollided = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		//EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		//transform.ongui; //transform.gameObject.AddComponent<GuiMenuScript>();	// Happens when player moves over it
		PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript>();
		if(player)
		{
			isCollided = true;
		}
	}

	void OnTriggerExit2D(Collider2D otherCollider)
	{
		//EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		//transform.ongui; //transform.gameObject.AddComponent<GuiMenuScript>();	// Happens when player moves over it
		PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript>();
		if(player)
		{
			isCollided = false;
		}
	}

	void OnGUI(){

		//buttons and shit
		if(isCollided){
			const int buttonWidth = 128;
	    	const int buttonHeight = 60;

			// Draw a button to start the game
		    if (GUI.Button(
		      // Center in X, 2/3 of the height in Y
		      new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight),
		      "START"
		      ))
		    {
		      // On Click, load the first level.
		      Application.LoadLevel("Stage1"); // "Stage1" is the scene name
		    }
		}else{
			//do nothing?
		}
	}
}
