using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
  /// <summary>
  /// Total hitpoints
  /// </summary>
  public float hp = 1;

  /// <summary>
  /// Enemy or player?
  /// </summary>
  public bool isEnemy = true;

  /// <summary>
  /// Inflicts damage and check if the object should be destroyed
  /// </summary>
  /// <param name="damageCount"></param>

    private GlobalPlayerScript globalPlayer;


  void Start(){
    globalPlayer = GameObject.Find("GlobalPlayerObject").GetComponent<GlobalPlayerScript>();
  }

  public void Damage(float damageCount)
  {
    hp -= damageCount;

    if (hp <= 0)
    {
      // Dead!

      globalPlayer.enemiesKilled += 1;
      SpecialEffectsHelper.Instance.Explosion(transform.position);
      SoundEffectsHelper.Instance.MakeExplosionSound();
      
      Destroy(gameObject);
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
        Damage(shot.damage);

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