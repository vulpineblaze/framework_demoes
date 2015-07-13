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

		PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript>();
		if(player)
		{

			if(menuTransform){
				menuTransform.gameObject.SetActive(true);
			}else{
					// Create a new shot
				menuTransform = Instantiate(menu) as Transform;

				// Assign position
				menuTransform.position = transform.position;
				menuTransform.rotation = transform.rotation;
			}

		}
	}

	void OnTriggerExit2D(Collider2D otherCollider)
	{

		PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript>();
		if(player)
		{
			menuTransform.gameObject.SetActive(false);
		}
	}

	

}
