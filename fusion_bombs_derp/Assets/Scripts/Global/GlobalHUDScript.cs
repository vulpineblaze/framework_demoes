using UnityEngine;
using System.Collections;

public class GlobalHUDScript : MonoBehaviour {

	private GlobalPlayerScript globalPlayer;
	private HealthScript playerHealth;

	private GameObject player;
	private float barPercent = 0;


	private Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(128,60);

	// looks good at 200 x 28 due to image size
	public Vector2 healthBarSize = new Vector2(200,28);

	public Texture2D emptyTex;
	public Texture2D fullTex;

	// Use this for initialization
	void Start () {
	    globalPlayer = GameObject.Find("GlobalPlayerObject").GetComponent<GlobalPlayerScript>();
	    player = GameObject.Find("Player");	
	    playerHealth = player.GetComponent<HealthScript>();
	    // skin = Resources.Load("GUISkin") as GUISkin;
	    // pos.x = Screen.width * 0.1f;
	    // pos.y = Screen.height * 0.1f;
	    pos = new Vector2(Screen.width * 0.1f,Screen.height * 0.1f);
	}

	void OnLevelWasLoaded(int level) {
        // if (level == 13)
        //     print("Woohoo");
        player = GameObject.Find("Player");	
	    playerHealth = player.GetComponent<HealthScript>();
	    // skin = Resources.Load("GUISkin") as GUISkin;
	    // pos.x = Screen.width * 0.1f;
	    // pos.y = Screen.height * 0.1f;
	    pos = new Vector2(Screen.width * 0.1f,Screen.height * 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
		barPercent =(float)(playerHealth.hp / globalPlayer.playerHealth);
	}

	void OnGUI()
	  {
	    // const int x = 128;
	    // const int y = 60;
	    // const int width = 128;
	    // const int height = 60;

	    // Set the skin to use
	    // GUI.skin = skin;
	    Debug.Log("hud: health " + playerHealth.hp + " | " + globalPlayer.playerHealth + " ; ");

	    if (Application.loadedLevelName != "Menu" ){
	    	// Draw a button to start the game
		    GUI.Label(
		      // X, Y, Width, Height
		      new Rect(pos.x * 1 - (size.x / 2), 
		      	pos.y - (size.y / 2), 
		      	size.x, 
		      	size.y),
		      	"Health: " + playerHealth.hp + " | " + globalPlayer.playerHealth + " "
		      );


		    GUI.Label(
		      // X, Y, Width, Height
		      new Rect(pos.x * 2 - (size.x / 2), 
		      	pos.y - (size.y / 2), 
		      	size.x, 
		      	size.y),
		      	"Resources: " + globalPlayer.currentResources 
		      );


		    GUI.Label(
		      // X, Y, Width, Height
		      new Rect(pos.x * 3 - (size.x / 2), 
		      	pos.y - (size.y / 2), 
		      	size.x, 
		      	size.y),
		      	"Kills: " + globalPlayer.enemiesKilled
		      );

		    GUI.BeginGroup(new Rect(
		    					pos.x * 4, 
		    					pos.y, 
		    					healthBarSize.x, 
		    					healthBarSize.y));
	             GUI.Box(new Rect(0,0, healthBarSize.x, healthBarSize.y), emptyTex);
	         
	             //draw the filled-in part:
	             GUI.BeginGroup(new Rect(0,0, healthBarSize.x * barPercent, healthBarSize.y));
	                 GUI.Box(new Rect(0,0, healthBarSize.x, healthBarSize.y), fullTex);
	             GUI.EndGroup();
	         GUI.EndGroup();

	    }
	    

	  }
}
