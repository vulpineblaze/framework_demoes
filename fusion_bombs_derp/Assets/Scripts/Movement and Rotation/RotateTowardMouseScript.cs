using UnityEngine;
using System.Collections;

public class RotateTowardMouseScript : MonoBehaviour {


  public bool InstantaneousRotation = false;
  // public Vector2 speed = new Vector2(50, 50);
  public float angleOffset = 0.0f;

  Vector3 mouse_pos ;
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

    }

  }// END UPDATE

}
