using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class SecondaryWeaponScript : MonoBehaviour
{
  //--------------------------------
  // 1 - Designer variables
  //--------------------------------

  /// <summary>
  /// Projectile prefab for shooting
  /// </summary>
  public Transform shotPrefab;
  public Vector2 positionOffset = new Vector2(0,0);

  public bool stuckToParent = false;

  /// <summary>
  /// Cooldown in seconds between two shots
  /// </summary>
  public float shootingRate = 0.25f;

  public float resourceCost = 5;

  private float shootCooldown;
  private Transform stuckShot;

  private GlobalPlayerScript globalPlayer;

  void Start()
  {
    shootCooldown = 0f;
    globalPlayer = GameObject.Find("GlobalPlayerObject").GetComponent<GlobalPlayerScript>();
  }

  void Update()
  {
    if (shootCooldown > 0)
    {
      shootCooldown -= Time.deltaTime;
    }

    if(stuckToParent && stuckShot != null){
      stuckShot.position = transform.position + new Vector3(positionOffset.x,positionOffset.y, 0f);
      stuckShot.rotation = transform.rotation;
    }
  }

  //--------------------------------
  // 3 - Shooting from another script
  //--------------------------------

  /// <summary>
  /// Create a new projectile if possible
  /// </summary>
  public void Attack(bool isEnemy)
  {
    if (CanAttack)
    {
      globalPlayer.currentResources -= resourceCost;

      
      shootCooldown = shootingRate;

      // Create a new shot
      var shotTransform = Instantiate(shotPrefab) as Transform;
      if(stuckToParent){
        stuckShot = shotTransform;
      }

      // Assign position
      shotTransform.position = transform.position + new Vector3(positionOffset.x,positionOffset.y, 0f);
      shotTransform.rotation = transform.rotation;

      // The is enemy property
      ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
      if (shot != null)
      {
        shot.isEnemyShot = isEnemy;
      }

      // Make the weapon shot always towards it
      MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
      if (move != null)
      {
        move.direction = this.transform.up; // towards in 2D space is the right of the sprite
      }
      
    }
  }

  /// <summary>
  /// Is the weapon ready to create a new projectile?
  /// </summary>
  public bool CanAttack
  {
    get
    {
      return (shootCooldown <= 0f)&&(globalPlayer.currentResources >= resourceCost);
    }
  }
}