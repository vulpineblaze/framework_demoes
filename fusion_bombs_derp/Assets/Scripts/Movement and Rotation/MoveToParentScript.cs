using UnityEngine;
using System.Collections;

public class MoveToParentScript : MonoBehaviour {


  private Transform target;
  public bool InstantaneousRotation = false;
  public Vector2 speed = new Vector2(1, 1);
  public int maxSpeed = 10;
  public float slerpSpeed = 10.0f;

  private Vector2 movement;


  bool continousRotation = true;

  // Use this for initialization
  void Start () {
    target = transform.parent;
  }
  
  // Update is called once per frame
  void Update () {


    if(continousRotation){
      if(InstantaneousRotation){continousRotation=false;}

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
