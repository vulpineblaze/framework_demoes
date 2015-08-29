using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

	public float damage = 10;
	public float durationOfExplosion = 2;
	// public float endScale = 1;
	public float targetScale = 1.0f;
 	// public float changeSpeed = 0.1f;


	private float maxDamage;
	private float cumulativeTime;

	// Use this for initialization
	void Start () 
	{
		maxDamage = damage;
		Destroy(gameObject, durationOfExplosion); // Subject to change very soon
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Vector3 scale = new Vector3(endScale,endScale,0);
		// transform.localScale = Vector3.Lerp (transform.localScale, scale, Time.deltaTime*timeToLive);
		// Need Scale to increase over time, probably use Delta time for this
		// Need Damage to decrease as Scale increases
		// Need object to destroy itself at max scale
		transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(targetScale, targetScale, 0), Time.deltaTime*(1/durationOfExplosion));
		cumulativeTime += Time.deltaTime;
		damage  = maxDamage - ((cumulativeTime*maxDamage)/(durationOfExplosion));
	}
}
