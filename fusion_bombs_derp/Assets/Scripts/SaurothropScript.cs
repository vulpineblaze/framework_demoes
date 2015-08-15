using UnityEngine;
using System.Collections;

public class SaurothropScript : MonoBehaviour {

	private GameObject player;
	private WeaponScript[] weapons;
	private WeaponScript closest;
	private float newDistance;
	private float bestDistance = 999999999999; // must be high
	private float[] testArray = new float[5];

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");	
	}
	
	void Awake()
	{
	// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();
	}

	// Update is called once per frame
	void Update () {
		newDistance = 0;
		bestDistance = 99999999999;
		int i = 0;
		foreach (WeaponScript weapon in weapons)
	    {
	      // Auto-fire

	    	newDistance = Vector3.Distance(player.transform.position, weapon.transform.position);
			
			testArray[i] = newDistance;
			i++;
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
