using UnityEngine;
using System.Collections;
 
public class LaserScript : MonoBehaviour
{

    public float maxLaserSize = 20f;

  [Header("Laser pieces")]
  public GameObject laserStart;
  public GameObject laserMiddle;
  public GameObject laserEnd;
 
  private GameObject start;
  private GameObject middle;
  private GameObject end;

  void Start()
  {
    // 2 - Limited time to live to avoid any leak
    Destroy(gameObject, 0.5f); // 20sec
  }
 
  void Update()
  {
    // Create the laser start from the prefab
  	// transform.position = transform.parent.position;
  	//transform.localPosition = Vector3.zero;


    float startSpriteWidth = 0f;
    if (start == null)
    {
      start = Instantiate(laserStart) as GameObject;
      start.transform.parent = transform;
      start.transform.localPosition = Vector2.zero;
      startSpriteWidth = start.GetComponent<Renderer>().bounds.size.x;
      start.transform.rotation = transform.rotation;
    }
 
    // Laser middle
    if (middle == null)
    {
      middle = Instantiate(laserMiddle) as GameObject;
      middle.transform.parent = transform;
      middle.transform.localPosition = Vector2.zero;
      middle.transform.rotation = transform.rotation;
    }
 
    // Define an "infinite" size, not too big but enough to go off screen
    float currentLaserSize = maxLaserSize;
    // Vector2 hitDistance = new Vector2(maxLaserSize,maxLaserSize);
    // Vector2 endPoint = new Vector2(0,0);
 
    // Raycast at the right as our sprite has been design for that
    Vector2 laserDirection = transform.right;
    RaycastHit2D hit = Physics2D.Raycast(transform.position, laserDirection, maxLaserSize);

    // RaycastHit2D hit = Physics2D.BoxCast( //this one almost worked
    // 									transform.position,
    // 									boxColliderSize,   //public Vector2 boxColliderSize = new Vector2(2.0f,2.0f);
    // 									transform.rotation.z,
    // 									laserDirection, 
    // 									maxLaserSize);
 
    if (hit.collider != null 
    	&& hit.collider.gameObject != end
    	&& hit.collider.gameObject.GetComponent<ShotScript>() == null
    	)
    {
      // We touched something!
 
      // -- Get the laser length
      currentLaserSize = Vector2.Distance(hit.point, transform.position);
      // endPoint = hit.point;
 
      // -- Create the end sprite
      if (end == null)
      {
        end = Instantiate(laserEnd) as GameObject;
        end.transform.parent = transform;
        end.transform.localPosition = Vector2.zero;
      	end.transform.rotation = transform.rotation;
      }
    }
    else
    {
      // Nothing hit
      // -- No more end
      if (end != null) Destroy(end);
    }
 
    // Place things
    // -- Gather some data
    // float startSpriteWidth = start.GetComponent<Renderer>().bounds.size.x
    // float startSpriteWidth = start.GetComponent<Renderer>().bounds.size.x * Mathf.Cos(transform.rotation.z);
    // float startSpriteWidth = start.GetComponent<Renderer>().bounds.size.x * Mathf.Asin(transform.rotation.z) * Mathf.Sign(transform.rotation.z);
    // float startSpriteWidth = start.GetComponent<Mesh>().bounds.size.x;
    float endSpriteWidth = 0f;
    if (end != null) endSpriteWidth = end.GetComponent<Renderer>().bounds.size.x;
 
    // -- the middle is after start and, as it has a center pivot, have a size of half the laser (minus start and end)
    middle.transform.localScale = new Vector3(currentLaserSize - startSpriteWidth, middle.transform.localScale.y, middle.transform.localScale.z);
    middle.transform.localPosition = new Vector2((currentLaserSize/2f), 0f);
 
    // End?
    if (end != null)
    {
    	// float angle = transform.rotation.z;
     //  end.transform.localPosition = new Vector2(currentLaserSize*Mathf.Cos(angle), Mathf.Sin(angle)*currentLaserSize);
     //  end.transform.localPosition = new Vector2(currentLaserSize*Mathf.Cos(angle), Mathf.Sin(angle)*currentLaserSize);
      end.transform.localPosition = new Vector2(currentLaserSize,0f);
      // end.transform.localPosition = endPoint;

    }
 
  }
}