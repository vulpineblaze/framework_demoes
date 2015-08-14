using UnityEngine;
using System.Collections;

public class SaurothropScript : MonoBehaviour {

	private GameObject player;
	private WeaponScript[] weapons;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Hand");	
	}
	
	void Awake()
	{
	// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();
	}

	// Update is called once per frame
	void Update () {
		float newDistance = 0;
		float bestDistance = 0;
		WeaponScript closest = null;
		foreach (WeaponScript weapon in weapons)
	    {
	      // Auto-fire
	    	newDistance = Vector3.Distance(player.transform.position, weapon.transform.position);
			if(newDistance < bestDistance){
				bestDistance = newDistance;
				closest = weapon;
			}			
	    }

	    //if weapon is closest then fire
    	if (closest != null && closest.CanAttack)
		{
			closest.Attack(true);
			SoundEffectsHelper.Instance.MakeEnemyShotSound();
		}

	}
}
