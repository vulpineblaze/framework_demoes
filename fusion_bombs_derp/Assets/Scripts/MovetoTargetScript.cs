using UnityEngine;
using System.Collections;

public class MovetoTargetScript : MonoBehaviour {


  public Transform target;
  public bool InstantaneousRotation = false;
  // public Vector2 speed = new Vector2(50, 50);
  public Vector2 speed = new Vector2(1, 1);
  public int maxSpeed = 10;
  public float slerpSpeed = 10.0f;

  
  // public float z_offset = 90;

  private Vector2 movement;


  // Vector3 mouse_pos ;
  // Transform target ; //Assign to the object you want to rotate
  // Vector3 object_pos ;
  // float angle ;

  bool continousRotation = true;

  // Use this for initialization
  void Start () {
  
  }
  
  // Update is called once per frame
  void Update () {


    if(continousRotation){
      if(InstantaneousRotation){continousRotation=false;}

      // var distance = (transform.position.z - Camera.main.transform.position.z) * lookFactor;
      //  var position = Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
      //  position = Camera.main.ScreenToWorldPoint(position);
      //  go.transform.LookAt(position);

      // Vector3 vectorToTarget = new Vector3(inputX, + inputY,0);
      // float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
      // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
      // transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10f);

      // var distance = (transform.position.z - Camera.main.transform.position.z) * 0.1;
      // var position = Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
      // position = Camera.main.ScreenToWorldPoint(position);
      // transform.LookAt(position);

      // Vector3 vectorToTarget = new Vector3(inputX, + inputY,0);
      // float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
      // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
      // transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10f);

      // mouse_pos = Input.mousePosition;
      // mouse_pos = target.position;

      // // mouse_pos.z = 5.23f; //The distance between the camera and object
      // // object_pos = Camera.main.WorldToScreenPoint(transform.position);
      // // mouse_pos.x = mouse_pos.x - object_pos.x;
      // // mouse_pos.y = mouse_pos.y - object_pos.y;
      // angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;   // Code that rotates the sprite
      // Vector3 z_vector = new Vector3(0.0f, 0.0f, (float)angle);        // Code that rotates the sprite
      // transform.rotation = Quaternion.Euler( z_vector );               // Code that rotates the sprite

      //removes extreme values of x,y and replaces with maxSpeed
      float clean_x = speed.x * (target.position.x - transform.position.x);
      float clean_y = speed.y * (target.position.y - transform.position.y);
      
      while( Mathf.Abs(clean_x) > Mathf.Abs(maxSpeed) || Mathf.Abs(clean_y) > Mathf.Abs(maxSpeed)){
        clean_x *= 0.9f;
        clean_y *= 0.9f;
      }

      movement = new Vector2(
        clean_x,
        clean_y);


      if(clean_x != 0 || clean_y != 0)
      {
        Vector3 vectorToTarget = new Vector3(clean_x, + clean_y,0);
        float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * slerpSpeed);
      }

    }


  }// END UPDATE

  void FixedUpdate()
  {
    // Apply movement to the rigidbody
    GetComponent<Rigidbody2D>().velocity = movement;
  }

}
