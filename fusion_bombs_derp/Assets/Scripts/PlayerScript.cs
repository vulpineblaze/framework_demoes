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

  void Update()
  {
    // 3 - Retrieve axis information
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    // 4 - Movement per direction
    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY);

    // Vector2 angle = new Vector2(inputX, + inputY);
    // Vector3 moveDirection = new Vector3 (0.0f, 0.0f, Vector2.Angle(angle, new Vector2(0, + 0)) );
	// Vector3 newDir = Vector3.RotateTowards(_transform.forward, _direction, _speed, 0.0F);
	// newDir = new Vector3(0,0,newDir.z);	
	// transform.rotation = Quaternion.LookRotation(newDir);
	// Vector3 vectorToTarget = targetTransform.position - transform.position;

	Vector3 vectorToTarget = new Vector3(inputX, + inputY,0);
	float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
	Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
	transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10f);
  }

  void FixedUpdate()
  {
    // 5 - Move the game object
    GetComponent<Rigidbody2D>().velocity = movement;
  }
}