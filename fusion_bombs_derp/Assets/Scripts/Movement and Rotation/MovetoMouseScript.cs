using UnityEngine;
using System.Collections;

public class MovetoMouseScript : MonoBehaviour {

  public bool InstantaneousRotation = false;
  // public Vector2 speed = new Vector2(50, 50);
  public Vector2 speed = new Vector2(1, 1);
  public int maxSpeed = 10;
  public float angleOffset = 0.0f;

  private Vector2 movement;


  Vector3 mouse_pos ;
  Transform target ; //Assign to the object you want to rotate
  Vector3 object_pos ;
  float angle ;

  bool continousRotation = true;

  // Use this for initialization
  void Start () {
  
  }
  
  // Update is called once per frame
  void Update () {


    if(continousRotation){
      if(InstantaneousRotation){continousRotation=false;}

      mouse_pos = Input.mousePosition;
      mouse_pos.z = 5.23f; //The distance between the camera and object
      object_pos = Camera.main.WorldToScreenPoint(transform.position);
      mouse_pos.x = mouse_pos.x - object_pos.x;
      mouse_pos.y = mouse_pos.y - object_pos.y;
      angle = angleOffset + Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;   // Code that rotates the sprite
      Vector3 z_vector = new Vector3(0.0f, 0.0f, (float)angle);        // Code that rotates the sprite
      transform.rotation = Quaternion.Euler( z_vector );               // Code that rotates the sprite

      //removes extreme values of x,y and replaces with maxSpeed
      float clean_x = speed.x * mouse_pos.x;
      float clean_y = speed.y * mouse_pos.y;
      
      while( Mathf.Abs(clean_x) > Mathf.Abs(maxSpeed) || Mathf.Abs(clean_y) > Mathf.Abs(maxSpeed)){
        clean_x *= 0.9f;
        clean_y *= 0.9f;
      }

      movement = new Vector2(
        clean_x,
        clean_y);

    }


  }// END UPDATE

  void FixedUpdate()
  {
    // Apply movement to the rigidbody
    GetComponent<Rigidbody2D>().velocity = movement;
  }

}
