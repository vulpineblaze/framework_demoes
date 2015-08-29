using UnityEngine;
using System.Collections;

public class PartialDamageScript : MonoBehaviour {

	/// <summary>
  /// Total hitpoints
  /// </summary>
  public float hp = 5;

  /// <summary>
  /// Enemy or player?
  /// </summary>
  public bool isEnemy = true;
  public float parentDamage= 1;

  private WeaponScript weapon;
  private HealthScript parentHealth;
  private bool canShoot = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		weapon = GetComponentInChildren<WeaponScript>();
		parentHealth = transform.parent.gameObject.GetComponent<HealthScript>();
	}

	public void Damage(float damageCount)
	  {
	    hp -= damageCount;

	    if (canShoot && hp <= 0 )
	    {
	      // Dead!
	      // Destroy(gameObject);
	    	canShoot = false;
	    	Destroy(weapon);
	    	SpecialEffectsHelper.Instance.Explosion(transform.position);
	    	SoundEffectsHelper.Instance.MakeExplosionSound();
	    	
	    	parentHealth.Damage(parentDamage);
	    }
	  }

	void OnTriggerEnter2D(Collider2D otherCollider)
  {
    // Is this a shot?
    ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
    BombScript bomb = otherCollider.gameObject.GetComponent<BombScript>();
    if (shot != null)
    {
      // Avoid friendly fire
      if (shot.isEnemyShot != isEnemy)
      {
      	if(canShoot){
        	Damage(shot.damage);
      	}

        // Destroy the shot
        Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
      }
    }
    if (bomb != null)
    {
      Damage(bomb.damage);
    }
  }

}
