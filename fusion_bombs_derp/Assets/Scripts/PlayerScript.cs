using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
  /// <summary>
  /// 1 - The speed of the ship
  /// </summary>
  public Vector2 speed = new Vector2(50, 50);

  // 2 - Store the movement
  private Vector2 movement;

  private WeaponScript[] weapons;

  private GlobalPlayerScript globalPlayer;


  void Start()
  {
    HealthScript playerHealth = this.GetComponent<HealthScript>();
    globalPlayer = GameObject.Find("GlobalPlayerObject").GetComponent<GlobalPlayerScript>();// FindObjectOfType(typeof(GlobalPlayerScript));
    playerHealth.hp = globalPlayer.playerHealth;

    // weapons = GetComponentsInChildren<WeaponScript>();
    // foreach (Transform child in transform) {
    //   weapons.add(child.GetComponent<WeaponScript>());
    // }

  }

  void Awake(){
    weapons = GetComponentsInChildren<WeaponScript>();
  }

  void Update()
  {
    // ...
    // globalPlayer.playerHealth = playerHealth.hp;
    // 5 - Shooting
    bool shoot = Input.GetButtonDown("Fire1");
    shoot |= Input.GetButtonDown("Fire2");
    // Careful: For Mac users, ctrl + arrow is a bad idea



    foreach (WeaponScript weapon in weapons) {
    // WeaponScript weapon = GetComponentInChildren<WeaponScript>();
      if (shoot)
      {
        // WeaponScript weapon = GetComponent<WeaponScript>();
        if (weapon != null)
        {
          // false because the player is not an enemy
          weapon.Attack(false);
        }
      }
    }

    // if (shoot)
    // {
    //   WeaponScript weapon = GetComponent<WeaponScript>();
    //   if (weapon != null)
    //   {
    //     // false because the player is not an enemy
    //     weapon.Attack(false);
    //   }
    // }
    // 3 - Retrieve axis information
    
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    // 4 - Movement per direction
    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY);

    if(inputX != 0 || inputY != 0)
    {
      Vector3 vectorToTarget = new Vector3(inputX, + inputY,0);
      float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
      Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
      transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10f);
    }
  }

  void FixedUpdate()
  {
    // 5 - Move the game object
    GetComponent<Rigidbody2D>().velocity = movement;
  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    bool damagePlayer = false;

    // Collision with enemy
    EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
    if (enemy != null)
    {
      // Kill the enemy
      HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
      if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

      damagePlayer = true;
    }

    // Damage the player
    if (damagePlayer)
    {
      HealthScript playerHealth = this.GetComponent<HealthScript>();
      if (playerHealth != null) playerHealth.Damage(1);
    }
  }
  void OnDestroy()
	{
	  // Game Over.
	  // Add the script to the parent because the current game
	  // object is likely going to be destroyed immediately.
	  transform.parent.gameObject.AddComponent<GameOverScript>();
	}
}