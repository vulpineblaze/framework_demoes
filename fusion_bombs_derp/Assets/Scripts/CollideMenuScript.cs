using UnityEngine;
using System.Collections;

public class CollideMenuScript : MonoBehaviour {

	// Use this for initialization
	public Transform menu;
	
	private Transform menuTransform;

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
				// Create a new shot
			menuTransform = Instantiate(menu) as Transform;

			// Assign position
			menuTransform.position = transform.position;
			menuTransform.rotation = transform.rotation;
		}
	}

	void OnTriggerExit2D(Collider2D otherCollider)
	{
		//EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		//transform.ongui; //transform.gameObject.AddComponent<GuiMenuScript>();	// Happens when player moves over it
		PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript>();
		if(player)
		{
			Destroy(menuTransform.gameObject);
		}
	}

	

}
