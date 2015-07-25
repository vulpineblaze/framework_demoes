using UnityEngine;
using System.Collections;

public class GalaxyMenuScript : MonoBehaviour {

	String availableLevels[];
	int windowWidth = 200;
	int windowHeight = 200;
	private boolean showMenu = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

/*
var availableLevels : String[]; 
var windowWidth : int = 200; 
var windowHeight : int = 200; 
private var showMenu : boolean = false;

function TriggerAction () { 
//Replace TriggerAction with your desired means of triggering the menu. 
showMenu = true; 
}

function OnGUI () { 
if (showMenu) 
{ 
GUI.Window(0, Rect((Screen.width / 2) - (windowWidth / 2), (Screen.height / 2) - (windowHeight / 2), windowWidth, windowHeight), LevelSelect, "Select a level!"); 
//Creates a window with ID 0 in the center of the screen using the function LevelSelect with the title, "Select a level!" } }

function LevelSelect (id : int) 
{ 
for (var levelName : String in availableLevels) 
{ 
if (GUILayout.Button(levelName)) 
{ Application.LoadLevel(levelName); } 
} if (GUILayout.Button("Cancel")) 
{ //Gives the player the opportunity to back out of the menu. showMenu = false; } 
}
*/